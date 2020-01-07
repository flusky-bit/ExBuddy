// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
    using ff14bot;
    using ff14bot.Managers;

    [XmlElement("EtxEquip")]
    public class EtxEquip : ExProfileBehavior
    {
        [XmlAttribute("ItemIds")]
        public int[] ItemIds { get; set; }

        [DefaultValue(true)]
        [XmlAttribute("NqOnly")]
        public bool NqOnly { get; set; }

        [DefaultValue(10000)]
        [XmlAttribute("MaxWait")]
        public int MaxWait { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxEquip] " + string.Format(text, args)); }

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
            if (ItemIds == null || ItemIds.Length <= 0) return isDone = true;
            foreach (var id in ItemIds)
                await EquipByItemId((uint) id, NqOnly);
            return isDone = true;
        }

        protected async Task<bool> EquipByItemId(
            uint itemId,
            bool nqOnly = true)
        {
            var slots = InventoryManager.FilledInventoryAndArmory;
            return
                await
                    EquipAllItems(
                        slots.Where(i => i.RawItemId == itemId && (!nqOnly || i.TrueItemId == itemId)));
        }

        protected async Task<bool> EquipAllItems(IEnumerable<BagSlot> bagSlots)
        {
            await Coroutine.Sleep(500);
            foreach (var bagSlot in bagSlots)
            {
                var name = bagSlot.Name;
                var startingId = bagSlot.TrueItemId;
                var i = 0;
                var itemCateg = bagSlot.Item.EquipmentCatagory.ToString();
                BagSlot equipSlot;
                var equippedSlot = new Dictionary<int, BagSlot>();
                foreach (var slot in InventoryManager.EquippedItems)
                {
                    equippedSlot[i] = slot;
                    i++;
                }
                if (itemCateg.Contains("Primary") || itemCateg.Contains("Arm"))
                    equipSlot = equippedSlot[0];
                else if (itemCateg.Contains("Secondary") || itemCateg.Contains("Shield"))
                    equipSlot = equippedSlot[1];
                else if (itemCateg.Contains("Soul"))
                    equipSlot = equippedSlot[13];
                else if (itemCateg.Contains("Ring") && equippedSlot[11].TrueItemId == startingId)
                    equipSlot = equippedSlot[12];
                else
                    switch (itemCateg)
                    {
                        case "Head":
                            equipSlot = equippedSlot[2];
                            break;
                        case "Body":
                            equipSlot = equippedSlot[3];
                            break;
                        case "Hands":
                            equipSlot = equippedSlot[4];
                            break;
                        case "Waist":
                            equipSlot = equippedSlot[5];
                            break;
                        case "Legs":
                            equipSlot = equippedSlot[6];
                            break;
                        case "Feet":
                            equipSlot = equippedSlot[7];
                            break;
                        case "Earrings":
                            equipSlot = equippedSlot[8];
                            break;
                        case "Necklace":
                            equipSlot = equippedSlot[9];
                            break;
                        case "Bracelets":
                            equipSlot = equippedSlot[10];
                            break;
                        case "Ring":
                            equipSlot = equippedSlot[11];
                            break;
                        default:
                            equipSlot = null;
                            break;
                    }
                if (equipSlot == null)
                    Log("You can not equip {0}.", name);
                else
                    while (equipSlot.TrueItemId != startingId)
                    {
                        Log("Attempting to equip {0}.", name);
                        bagSlot.Move(equipSlot);
                        if (await Coroutine.Wait(MaxWait, () => equipSlot.TrueItemId == startingId))
                            Log("{0} equipped successfully.", name);
                        else
                            Log("Failed to equip {0}.", name);
                    }
                await Coroutine.Sleep(1500);
            }
            return true;
        }
    }
}