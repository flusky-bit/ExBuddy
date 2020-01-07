namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using ExBuddy.Attributes;
	using ExBuddy.Helpers;
	using ExBuddy.Interfaces;
	using ff14bot;
	using System.Threading.Tasks;

	//Name, RequiredTime, RequiredGpBreakpoints
	[GatheringRotation("Unspoiled", 21, 500, 0)]
	public sealed class UnspoiledGatheringRotation : GatheringRotation, IGetOverridePriority
	{
		#region IGetOverridePriority Members

		int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
		{
			if (tag.Node.IsUnspoiled() && tag.CollectableItem == null)
			{
				return 8000;
			}

			return -1;
		}

		#endregion IGetOverridePriority Members

		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			if (Core.Player.CurrentGP >= 500)
			{
				await tag.Cast(Ability.IncreaseGatherYield2);
			}

			return await base.ExecuteRotation(tag);
		}

		public override async Task<bool> Prepare(ExGatherTag tag)
		{
			await Wait();
            
			if (tag.GatherItem.CanGather)
			{
				return await base.Prepare(tag);
			}
			else
			{
				return tag.GatherItem.TryGatherItem() && await base.Prepare(tag);
			}
		}
	}
}