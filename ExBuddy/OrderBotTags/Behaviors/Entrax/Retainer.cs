// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System.Linq;
    using System.Threading.Tasks;
	using System;
	using System.Runtime.CompilerServices;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
	using ff14bot;
    using ff14bot.Managers;
	using ff14bot.NeoProfiles;
    using ff14bot.RemoteWindows;

    [XmlElement("EtxRetainer")]
    public class EtxRetainer : ExProfileBehavior
    {
        public new void Log(string text, params object[] args) { Logger.Mew("[EtxRetainer] " + string.Format(text, args)); }

        protected override async Task<bool> Main()
        {
            foreach (var unit in GameObjectManager.GameObjects.OrderBy(r => r.Distance()))
                if (unit.Name == "传唤铃" || unit.NpcId == 2000401 || unit.NpcId == 2000441)
                {
                    unit.Interact();
                    break;
                }
			if (!await Coroutine.Wait(3000, () => SelectString.IsOpen)) {
				if (RaptureAtkUnitManager.GetWindowByName("RetainerList")==null)
				{
					return isDone = true;
				}
				
				const int Offset0 = 0x1CA;
				const int Offset2 = 0x160;
				var elementCount = Core.Memory.Read<ushort>(RaptureAtkUnitManager.GetWindowByName("RetainerList").Pointer + Offset0);
				var addr = Core.Memory.Read<IntPtr>(RaptureAtkUnitManager.GetWindowByName("RetainerList").Pointer + Offset2);
				TwoInt[] elements = Core.Memory.ReadArray<TwoInt>(addr, elementCount);
				int NumberOfRetainers = elements[2].TrimmedData;
				for (var i = 0; i < NumberOfRetainers; i++) 
				{
					RaptureAtkUnitManager.GetWindowByName("RetainerList").SendAction(2, 3UL, 2UL, 3UL, (ulong) i);
					await Coroutine.Sleep(300);
					await Coroutine.Wait(9000, () => Talk.DialogOpen);
					Talk.Next();

					if (!await Coroutine.Wait(5000, () => SelectString.IsOpen)) return isDone = true;
					foreach (var retainer in SelectString.Lines())
					{
						if (retainer.EndsWith("[结束]") || retainer.EndsWith("[Tâche terminée]") || retainer.EndsWith("(Venture complete)"))
						{
							Log("探险结束!");
							SelectString.ClickSlot(5);
							if (!await Coroutine.Wait(5000, () => RetainerTaskResult.IsOpen)) continue;
							RetainerTaskResult.Reassign();
							if (!await Coroutine.Wait(5000, () => RetainerTaskAsk.IsOpen)) continue;
							RetainerTaskAsk.Confirm();
							if (!await Coroutine.Wait(5000, () => Talk.DialogOpen)) continue;
							Talk.Next();
							if (!await Coroutine.Wait(5000, () => SelectString.IsOpen)) continue;
						}
					}
					
					SelectString.ClickSlot((uint) SelectString.LineCount - 1);
					if (!await Coroutine.Wait(5000, () => Talk.DialogOpen)) continue;
					Talk.Next();
					await Coroutine.Sleep(3000);
				}
				RaptureAtkUnitManager.GetWindowByName("RetainerList").SendAction(1, 3uL, 4294967295uL);
			}
			return isDone = true;

        }
    }
}