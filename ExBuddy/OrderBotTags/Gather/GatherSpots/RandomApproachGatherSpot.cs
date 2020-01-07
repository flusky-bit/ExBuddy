namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
	using Buddy.Coroutines;
	using Clio.XmlEngine;
	using ExBuddy.Helpers;
	using ff14bot;
	using ff14bot.Navigation;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using ff14bot.Behavior;
	using ff14bot.Managers;

    [XmlElement("RandomApproachGatherSpot")]
	public class RandomApproachGatherSpot : GatherSpot
	{
		private HotSpot approachLocation;

		[XmlElement("HotSpots")]
		public List<HotSpot> HotSpots { get; set; }

		[XmlAttribute("ReturnToApproachLocation")]
		public bool ReturnToApproachLocation { get; set; }

		[XmlAttribute("Stealth")]
		public bool Stealth { get; set; }

		[XmlAttribute("UnstealthAfter")]
		public bool UnstealthAfter { get; set; }

		public override async Task<bool> MoveFromSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving from " + this;

			var result = true;
			if (ReturnToApproachLocation)
			{
				result &= await approachLocation.MoveToOnGround();
			}

			if (UnstealthAfter && Core.Player.HasAura((int)AbilityAura.Stealth))
			{
				result &= await tag.CastAura(Ability.Stealth);
			}

			//change the approach location for the next time we go to this node.
			approachLocation = HotSpots.Shuffle().First();

			return result;
		}

		public override async Task<bool> MoveToSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving to " + this;

			if (HotSpots == null || HotSpots.Count == 0)
			{
				return false;
			}

			if (approachLocation == null)
				approachLocation = HotSpots.Shuffle().First();

			var result = await approachLocation.MoveTo(dismountAtDestination: Stealth);

		    if (!result) return false;

		    var landed = MovementManager.IsDiving || await NewNewLandingTask();
		    if (landed && Core.Player.IsMounted && !MovementManager.IsDiving)
                ActionManager.Dismount();

            Navigator.Stop();
            await Coroutine.Yield();

		    if (Stealth)
		    {
		        await tag.CastAura(Ability.Stealth, AbilityAura.Stealth);
		    }

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