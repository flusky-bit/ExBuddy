namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using ExBuddy.Attributes;
	using ExBuddy.Interfaces;
	using ff14bot;
	using System.Threading.Tasks;

	// Get One ++
	[GatheringRotation("Collect600", 35, 600)]
	public sealed class Collect600GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
	{
		#region IGetOverridePriority Members

		int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
		{
			// if we have a collectable && the collectable value is greater than or equal to 600: Priority 600
			if (tag.CollectableItem != null && tag.CollectableItem.Value >= 600)
			{
				return 600;
			}

			return -1;
		}

		#endregion IGetOverridePriority Members

		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			if (Core.Player.CurrentGP >= 600)
			{
				bool utmostCaution = true;
				bool singleMind = true;
				await Impulsive(tag);

				if (HasDiscerningEye)
				{
					await UtmostSingleMind(tag);
					utmostCaution = false;
				}

				await Impulsive(tag);

				if (HasDiscerningEye)
				{
					if (utmostCaution)
					{
						await UtmostSingleMind(tag);
						utmostCaution = false;
					}
					else
					{
						await SingleMind(tag);
						singleMind = false;
					}
				}

				await Impulsive(tag);

				if (!utmostCaution)
				{
					if (singleMind)
					{
						await SingleMind(tag);
					}
					await Instinctual(tag);
					await IncreaseChance(tag);
				}
			}
			else
			{
				await Impulsive(tag);
				await Impulsive(tag);
				await Instinctual(tag);
			}

			return true;
		}
	}
}