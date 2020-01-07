namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
    using Buddy.Coroutines;
    using Clio.Utilities;
    using Clio.XmlEngine;
    using ExBuddy.Helpers;
    using ff14bot;
    using ff14bot.Managers;
    using ff14bot.Navigation;
    using System.ComponentModel;
    using System.Threading.Tasks;

    [XmlElement("StealthApproachGatherSpot")]
    public class StealthApproachGatherSpot : GatherSpot
    {
        [DefaultValue(true)]
        [XmlAttribute("ReturnToStealthLocation")]
        [XmlAttribute("ReturnToApproachLocation")]
        public bool ReturnToStealthLocation { get; set; }

        [XmlAttribute("StealthLocation")]
        [XmlAttribute("ApproachLocation")]
        public Vector3 StealthLocation { get; set; }

        [XmlAttribute("UnstealthAfter")]
        public bool UnstealthAfter { get; set; }

#if RB_CN
		public override async Task<bool> MoveFromSpot(ExGatherTag tag)
		{
            tag.StatusText = "Moving from " + this;

			var result = true;
			if (ReturnToStealthLocation)
			{
				result &= await StealthLocation.MoveToOnGroundNoMount(tag.Distance, tag.Node.EnglishName, tag.MovementStopCallback);
			}

			if (UnstealthAfter && Core.Player.HasAura((int)AbilityAura.Stealth))
			{
				result &= await tag.CastAura(Ability.Stealth);
			}

			return result;
		}

		public override async Task<bool> MoveToSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving to " + this;

			if (StealthLocation == Vector3.Zero)
			{
				return false;
			}

			var result =
				await
					StealthLocation.MoveTo(
						UseMesh,
						radius: tag.Radius,
						name: "Stealth Location",
						stopCallback: tag.MovementStopCallback,
						dismountAtDestination: true);

            if (!result) return false;

		    var landed = MovementManager.IsDiving || await NewNewLandingTask();
		    if (landed && Core.Player.IsMounted)
		        ActionManager.Dismount();

            Navigator.Stop();
            await Coroutine.Yield();

		    await tag.CastAura(Ability.Stealth, AbilityAura.Stealth);

		    result = await NodeLocation.MoveToOnGroundNoMount(tag.Distance, tag.Node.EnglishName, tag.MovementStopCallback);

            return result;
        }

        private async Task<bool> NewNewLandingTask()
        {
            if (!MovementManager.IsFlying) { return true; }

            while (MovementManager.IsFlying) { ActionManager.Dismount(); await Coroutine.Sleep(500); }
            return true;
        }

        public override string ToString()
		{
			return this.DynamicToString("UnstealthAfter");
		}
#else

        [XmlAttribute("NodeLocation")]
        public Vector3 NodeLocation { get; set; }

        public virtual async Task<bool> MoveFromSpot(ExGatherTag tag)
        {
            tag.StatusText = "Moving from " + this;

            return true;
        }

        public virtual async Task<bool> MoveToSpot(ExGatherTag tag)
        {
            tag.StatusText = "Moving to " + this;

            var randomApproachLocation = NodeLocation;

            if (MovementManager.IsDiving)
            {
                randomApproachLocation = NodeLocation.AddRandomDirection(3f, SphereType.TopHalf);
            }

            var result = await
                randomApproachLocation.MoveTo(
                    UseMesh,
                    radius: tag.Distance,
                    name: tag.Node.EnglishName,
                    stopCallback: tag.MovementStopCallback);

            if (!result) return false;

            var landed = MovementManager.IsDiving || await NewNewLandingTask();
            if (landed && Core.Player.IsMounted && !MovementManager.IsDiving)
                ActionManager.Dismount();

            Navigator.Stop();
            await Coroutine.Yield();

            result = !MovementManager.IsDiving || await NodeLocation.MoveToOnGroundNoMount(tag.Distance, tag.Node.EnglishName, tag.MovementStopCallback);

            return result;
        }

        private async Task<bool> NewNewLandingTask()
        {
            if (!MovementManager.IsFlying) { return true; }

            while (MovementManager.IsFlying) { ActionManager.Dismount(); await Coroutine.Sleep(500); }
            return true;
        }
#endif
    }
}