namespace ExBuddy.Windows
{
    using System.Threading.Tasks;
    using Enumerations;
    using ff14bot.Managers;
    using Helpers;

    public sealed class HarpoonTip : Window<HarpoonTip>
    {
        public HarpoonTip()
            : base("HarpoonTip")
        {
        }

        public async Task<bool> SelectGiG(
            int gigId,
            ushort baitDelay = 200,
            ushort maxWait = 2000)
        {
            if (!IsValid)
            {
                ActionManager.DoAction(7634, GameObjectManager.LocalPlayer);
                await Refresh(maxWait);
                await Behaviors.Sleep(maxWait);
            }

            var result = SendActionResult.None;
            var attempts = 0;
            while (result != SendActionResult.Success && attempts++ < 3
                   && Behaviors.ShouldContinue)
            {
                result = SetGig(gigId);
                if (result == SendActionResult.InjectionError)
                    await Behaviors.Sleep(500);

                await Behaviors.Wait(maxWait, () => !Window<HarpoonTip>.IsOpen);
            }

            return result > SendActionResult.InjectionError;
        }

        public SendActionResult SetGig(int gigId) { return Control.TrySendAction(1, 3, (uint) gigId); }
    }
}