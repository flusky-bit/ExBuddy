namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using Attributes;
	using ff14bot;
	using ff14bot.Managers;
	using System.Threading.Tasks;

	[GatheringRotation("EarthElement", 30, 400)]
	public sealed class EarthElementGatheringRotation : SmartGatheringRotation
	{
		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			if (Core.Player.CurrentGP > 399)
			{
				await Wait();
				ActionManager.DoAction(217U, Core.Player);
			}

			return await base.ExecuteRotation(tag);
		}
	}
}