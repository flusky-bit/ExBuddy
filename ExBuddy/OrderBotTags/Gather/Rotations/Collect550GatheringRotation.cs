namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using ExBuddy.Attributes;
	using ExBuddy.Interfaces;
	using ff14bot;
	using System.Threading.Tasks;
	using Helpers;

    // Get One ++
	[GatheringRotation("Collect550", 33, 600)]
	public sealed class Collect550GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
	{
		#region IGetOverridePriority Members

		int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
		{
			// if we have a collectable && the collectable value is greater than or equal to 550: Priority 550
			if (tag.CollectableItem != null && tag.CollectableItem.Value >= 550)
			{
				return 550;
			}

			return -1;
		}

		#endregion IGetOverridePriority Members

		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			if (tag.Node.IsUnspoiled())
			{
				await UtmostCaution(tag);
				await AppraiseAndRebuff(tag);
				await Methodical(tag);
				await AppraiseAndRebuff(tag);
				await Methodical(tag);
				await IncreaseChance(tag);
			}
			else
			{
				if (Core.Player.CurrentGP >= 600)
				{
						var appraisalsRemaining = 4;
						await Impulsive(tag);
						appraisalsRemaining--;

						if (HasDiscerningEye)
						{
							await UtmostSingleMindMethodical(tag);
							appraisalsRemaining--;
						}

						await Impulsive(tag);
						appraisalsRemaining--;

						if (HasDiscerningEye)
						{
							if (appraisalsRemaining == 1)
							{
								await SingleMindMethodical(tag);
							}
							else
							{
								await UtmostSingleMindMethodical(tag);
							}
							appraisalsRemaining--;
						}

						if (appraisalsRemaining == 2)
						{
							await Methodical(tag);
						}

						if (appraisalsRemaining == 1)
						{
							await SingleMindMethodical(tag);
						}

						await IncreaseChance(tag);
						return true;
				}

				await Impulsive(tag);
				await Impulsive(tag);
			    await Instinctual(tag);

                return true;
			}

			return true;
		}
	}
}