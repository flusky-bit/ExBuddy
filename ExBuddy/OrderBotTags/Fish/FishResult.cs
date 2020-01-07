namespace ExBuddy.OrderBotTags.Fish
{
	using ExBuddy.Enumerations;
	using System;

	public class FishResult
	{
		public string FishName =>
#if !RB_CN
		    IsHighQuality
		        ? Name.Substring(0, Name.Length - 2)
		        :
#endif
		        Name;

        public bool IsHighQuality { get; set; }

		public string Name { get; set; }

		public float Size { get; set; }

		public bool IsKeeper(Keeper keeper)
		{
			if (!string.Equals(keeper.Name, FishName, StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}

			if ((!keeper.Action.HasFlag(KeeperAction.KeepHq) && IsHighQuality))
			{
				return false;
			}

			return keeper.Action.HasFlag(KeeperAction.KeepNq) || IsHighQuality;
		}

        public bool ShouldMooch(Keeper keeper) => keeper.Action.HasFlag((KeeperAction)0x04);
    }
}