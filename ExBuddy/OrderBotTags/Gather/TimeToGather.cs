namespace ExBuddy.OrderBotTags.Gather
{
    using Helpers;

    public struct TimeToGather
	{
#pragma warning disable 414
		public int EorzeaMinutesTillDespawn;
#pragma warning restore 414
		public int RealSecondsTillStartGathering;

		public int TicksTillStartGathering
		{
			get { return EorzeaTimeHelper.ConvertSecondsToTicks(RealSecondsTillStartGathering); }
		}
	}
}