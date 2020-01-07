#pragma warning disable 1998

namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
    using Clio.Utilities;
	using Clio.XmlEngine;
	using ExBuddy.Helpers;
	using ExBuddy.Interfaces;
	using System.ComponentModel;
    using System.Threading.Tasks;
    using Buddy.Coroutines;
    using ff14bot;
    using ff14bot.Behavior;
    using ff14bot.Managers;
    using ff14bot.Navigation;

    [XmlElement("GatherSpot")]
	public class GatherSpot : IGatherSpot
	{
		[DefaultValue(true)]
		[XmlAttribute("UseMesh")]
		public bool UseMesh { get; set; }

		public override string ToString()
		{
			return this.DynamicToString();
		}

		#region IGatherSpot Members

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

        #endregion IGatherSpot Members
    }
}