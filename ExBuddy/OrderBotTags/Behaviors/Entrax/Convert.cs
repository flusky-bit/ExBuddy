// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
    using ff14bot;
    using ff14bot.Behavior;
    using ff14bot.Enums;
    using ff14bot.Managers;

    [XmlElement("EtxConvert")]
    public class EtxConvert : ExProfileBehavior
    {
        [XmlAttribute("ItemIds")]
        public int[] ItemIds { get; set; }

        [DefaultValue(5000)]
        [XmlAttribute("MaxWait")]
        public int MaxWait { get; set; }

        [DefaultValue(true)]
        [XmlAttribute("NqOnly")]
        public bool NqOnly { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxConvert] " + string.Format(text, args)); }

        protected override async Task<bool> Main()
        {
            if (GatheringManager.WindowOpen)
            {
                Log("Waiting for gathering window to close");
                await Coroutine.Sleep(2000);
            }
            if (FishingManager.State != FishingState.None)
            {
                Log("Stop fishing");
                ActionManager.DoAction("Quit", Core.Me);
                await Coroutine.Wait(5000, () => FishingManager.State == FishingState.None);
            }
            await CommonTasks.StopAndDismount();
            if (ItemIds == null || ItemIds.Length <= 0) return isDone = true;
            foreach (var id in ItemIds)
                await ConvertByItemId((uint) id, (ushort) MaxWait, NqOnly);
            return isDone = true;
        }

        protected async Task<bool> ConvertByItemId(
            uint itemId,
            ushort maxWait = 5000,
            bool nqOnly = true)
        {
            var slots = InventoryManager.EquippedItems;
            return
                await
                    ConvertAllItems(
                        slots.Where(i => i.RawItemId == itemId && (!nqOnly || i.TrueItemId == itemId) && Math.Abs(i.SpiritBond - 100.0) < 0.01),
                        maxWait);
        }

        protected async Task<bool> ConvertAllItems(
            IEnumerable<BagSlot> bagSlots,
            ushort maxWait)
        {
            foreach (var bagSlot in bagSlots)
            {
                var name = bagSlot.Name;
                Log("Attempting to convert {0}.", name);
                if (bagSlot.Item != null && (bagSlot.Item.Unique || bagSlot.Item.Untradeable))
                    continue;
                var startingId = bagSlot.TrueItemId;
                //Check to make sure the bagslots contents doesn't change
                while (bagSlot.TrueItemId == startingId && bagSlot.Count > 0)
                {
                    var result = await CommonTasks.ConvertToMateria(bagSlot, maxWait);
                    if (result.HasFlag(SpiritbondResult.Success)) continue;
                    Log("Unable to convert \"{0}\" due to {1}.", name, result);
                    break;
                }
                await Coroutine.Sleep(500);
            }
            return true;
        }
    }
}