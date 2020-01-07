namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
	using Buddy.Coroutines;
	using Clio.Utilities;
	using Clio.XmlEngine;
	using ExBuddy.Helpers;
	using System.ComponentModel;
	using System.Threading.Tasks;
	using ff14bot;
	using ff14bot.Behavior;
	using ff14bot.Managers;
	using ff14bot.Navigation;

    [XmlElement("IndirectApproachGatherSpot")]
	public class IndirectApproachGatherSpot : GatherSpot
	{
		[XmlAttribute("ApproachLocation")]
		public Vector3 ApproachLocation { get; set; }

		[DefaultValue(true)]
		[XmlAttribute("ReturnToApproachLocation")]
		public bool ReturnToApproachLocation { get; set; }

		public override async Task<bool> MoveFromSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving from " + this;

			var result = true;
			if (ReturnToApproachLocation)
			{
				result &= await ApproachLocation.MoveToOnGroundNoMount(tag.Distance, tag.Node.EnglishName, tag.MovementStopCallback);
			}

			return result;
		}

		public override async Task<bool> MoveToSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving to " + this;

			if (ApproachLocation == Vector3.Zero)
			{
				return false;
			}

			var result =
				await
					ApproachLocation.MoveTo(
						UseMesh,
						radius: tag.Distance,
						name: "Approach Location",
						stopCallback: tag.MovementStopCallback);

		    if (!result) return false;

		    var landed = MovementManager.IsDiving || await NewNewLandingTask();
		    if (landed && Core.Player.IsMounted && !MovementManager.IsDiving)
                ActionManager.Dismount();

            Navigator.Stop();
            await Coroutine.Yield();

		    result = await NodeLocation.MoveToOnGroundNoMount(tag.Distance, tag.Node.EnglishName, tag.MovementStopCallback);

		    return result;
        }

        private async Task<bool> NewNewLandingTask()
        {
            if (!MovementManager.IsFlying) { return true; }

            while (MovementManager.IsFlying) { ActionManager.Dismount(); await Coroutine.Sleep(500); }
            return true;
        }
    }
}