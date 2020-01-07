namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using Attributes;
	using ff14bot;
	using ff14bot.Managers;
	using System.Threading.Tasks;

	[GatheringRotation("WaterElement", 30, 400)]
	public sealed class WaterElementGatheringRotation : SmartGatheringRotation
	{
		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			if (Core.Player.CurrentGP > 399)
			{
				await Wait();
				ActionManager.DoAction(293U, Core.Player);
			}

			return await base.ExecuteRotation(tag);
		}
	}
}