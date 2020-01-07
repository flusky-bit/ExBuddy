// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
    using ff14bot;
    using ff14bot.Managers;
    using ff14bot.RemoteWindows;

    [XmlElement("EtxUseAuraItem")]
    public class EtxUseAuraItem : ExProfileBehavior
    {
        private Item _itemData;
        private BagSlot _itemslot;

        [XmlAttribute("ItemId")]
        public uint ItemId { get; set; }

        [XmlAttribute("AuraId")]
        public uint AuraId { get; set; }

        [XmlAttribute("MinDuration")]
        [DefaultValue(5)]
        public int MinDuration { get; set; }

        [XmlAttribute("HqOnly")]
        public bool HqOnly { get; set; }

        [XmlAttribute("NqOnly")]
        public bool NqOnly { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxUseAuraItem] " + string.Format(text, args)); }

        protected override void OnStart()
        {
            _itemData = DataManager.GetItem(ItemId);
            if (_itemData == null)
            {
                TreeRoot.Stop("Couldn't locate item with id of " + ItemId);
                return;
            }

            if (HqOnly && NqOnly)
            {
                TreeRoot.Stop($"Both HqOnly and NqOnly cannot be true");
                return;
            }

            var validItems = InventoryManager.FilledSlots.Where(r => r.RawItemId == ItemId).ToArray();

            if (validItems.Length == 0)
            {
                TreeRoot.Stop($"We don't have any {_itemData.CurrentLocaleName} {ItemId} in our inventory.");
                return;
            }

            if (HqOnly)
            {
                var items = validItems.Where(r => r.IsHighQuality).ToArray();
                if (items.Any())
                    _itemslot = items.FirstOrDefault();
                else
                    TreeRoot.Stop("HqOnly and we don't have any Hq in the inventory with id " + ItemId);
            }
            else if (NqOnly)
            {
                var items = validItems.Where(r => !r.IsHighQuality).ToArray();
                if (items.Any())
                    _itemslot = items.FirstOrDefault();
                else
                    TreeRoot.Stop("NqOnly and we don't have any Nq in the inventory with id " + ItemId);
            }
            else
            {
                _itemslot = validItems.OrderBy(r => r.IsHighQuality).FirstOrDefault();
            }
        }

        protected override async Task<bool> Main()
        {
            var shouldUse = false;
            var alreadyPresent = false;
            if (Core.Player.HasAura(AuraId))
            {
                var auraInfo = Core.Player.GetAuraById(AuraId);
                if (auraInfo.TimespanLeft.TotalMinutes < MinDuration)
                {
                    shouldUse = true;
                    alreadyPresent = true;
                }
            }
            else
            {
                shouldUse = true;
            }

            if (!shouldUse) return isDone = true;
            if (CraftingLog.IsOpen || CraftingManager.IsCrafting)
            {
                await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => CraftingLog.IsOpen);
                await Coroutine.Sleep(1000);
                CraftingLog.Close();
                await Coroutine.Yield();
                await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => !CraftingLog.IsOpen);
                await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => !CraftingManager.AnimationLocked);
            }

            Log("Waiting until the item is usable.");
            await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => _itemslot.CanUse());

            Log("Using {0}", _itemData.CurrentLocaleName);
            _itemslot.UseItem();
            await Coroutine.Sleep(4000);

            if (!alreadyPresent)
            {
                Log("Waiting for the aura to appear");
                await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => Core.Player.HasAura(AuraId));
            }
            else
            {
                Log("Waiting until the duration is refreshed");
                await Coroutine.Wait(Timeout.InfiniteTimeSpan, () => Core.Player.GetAuraById(AuraId).TimespanLeft.TotalMinutes > MinDuration);
            }
            return isDone = true;
        }
    }
}