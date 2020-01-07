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

    [XmlElement("EtxDesynth")]
    public class EtxDesynth : ExProfileBehavior
    {
        [XmlAttribute("ItemIds")]
        public int[] ItemIds { get; set; }

        [DefaultValue(6000)]
        [XmlAttribute("DesynthDelay")]
        public int DesynthDelay { get; set; }

        [DefaultValue(10)]
        [XmlAttribute("DesynthTimeout")]
        public int DesynthTimeout { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxDesynth] " + string.Format(text, args)); }

        protected override async Task<bool> Main()
        {
            if (!Core.Player.DesynthesisUnlocked)
            {
                Log("You have not unlocked the desynthesis ability.");
                return isDone = true;
            }
            IEnumerable<BagSlot> desynthables;
            if (ItemIds != null)
            {
                desynthables =
                    InventoryManager.FilledSlots.Where(bs => Array.Exists(ItemIds, e => e == bs.RawItemId) && bs.IsDesynthesizable && bs.CanDesynthesize);
            }
            else
            {
                Log("You didn't specify anything to desynthesize.");
                return isDone = true;
            }
            IEnumerable<BagSlot> bagSlots = desynthables as IList<BagSlot> ?? desynthables.ToList();
            var numItems = bagSlots.Count();
            if (numItems == 0)
            {
                Log("None of the items you requested can be desynthesized.");
                return isDone = true;
            }
            var i = 1;
            foreach (var bagSlot in bagSlots)
            {
                var name = bagSlot.Name;
                Log("Attempting to desynthesize item {0} (\"{1}\") of {2}.", i++, name, numItems);
                var result = await CommonTasks.Desynthesize(bagSlot, DesynthDelay);
                if (result != DesynthesisResult.Success)
                {
                    Log("Unable to desynthesize \"{0}\" due to {1}.", name, result);
                    continue;
                }
                await Coroutine.Wait(DesynthTimeout * 1000, () => !bagSlot.IsFilled || !bagSlot.Name.Equals(name));
                if (bagSlot.IsFilled && bagSlot.EnglishName.Equals(name))
                    Log("Timed out awaiting desynthesis of \"{0}\" ({1} seconds).", name, DesynthTimeout);
                else
                    Log("Desynthed \"{0}\".", name);
            }
            return isDone = true;
        }
    }
}