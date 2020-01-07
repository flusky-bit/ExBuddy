// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
    using ff14bot;
    using ff14bot.Behavior;
    using ff14bot.Managers;
    using ff14bot.Navigation;

    [XmlElement("EtxTeleportTo")]
    public class EtxTeleportTo : ExProfileBehavior
    {
        [XmlAttribute("AetheryteId")]
        public uint AetheryteId { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxTeleportTo] " + string.Format(text, args)); }

        protected override async Task<bool> Main()
        {
            var ticks = 0;
            while (MovementManager.IsMoving && ticks++ < 5)
            {
                Navigator.Stop();
                await Coroutine.Sleep(240);
            }

            ticks = 0;
            var casted = false;
            while (!Core.Player.IsCasting && !CommonBehaviors.IsLoading && ticks++ < 5)
            {
                if (!Core.Player.IsCasting && casted)
                    break;

                if (!Core.Player.IsCasting && !CommonBehaviors.IsLoading)
                {
                    WorldManager.TeleportById(AetheryteId);
                    await Coroutine.Sleep(500);
                }

                casted = casted || Core.Player.IsCasting;
                await Coroutine.Yield();
            }

            await Coroutine.Wait(10000, () => CommonBehaviors.IsLoading);
            await Coroutine.Wait(100000, () => !CommonBehaviors.IsLoading);

            return isDone = true;
        }
    }
}