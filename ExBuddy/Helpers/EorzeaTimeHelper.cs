namespace ExBuddy.Helpers
{
    public static class EorzeaTimeHelper
    {
        public static int ConvertTicksToSeconds(int ticks)
        {
            return ticks * 3;
        }

        public static int ConvertSecondsToTicks(int seconds)
        {
            return seconds / 3;
        }
    }
}
