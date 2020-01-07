// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using Clio.XmlEngine;
    using ff14bot;

    [XmlElement("EtxStopBot")]
    public class EtxStopBot : ExProfileBehavior
    {
        protected override async Task<bool> Main()
        {
            while (TreeRoot.IsRunning)
            {
                TreeRoot.Stop();
                await Coroutine.Wait(1000, () => !TreeRoot.IsRunning);
            }
            return isDone = true;
        }
    }
}