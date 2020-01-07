namespace ExBuddy.OrderBotTags.Gather
{
    using System;
    using Interfaces;

    public class SpearResult
    {
        public string FishName =>
#if !RB_CN
            IsHighQuality
                ? Name.Substring(0, Name.Length - 2)
                :
#endif
                Name;

        public string FishNames =>
#if !RB_CN
            IsHighQuality
                ? Name.Substring(0, Name.Length - 3)
                : Name.Substring(0, Name.Length - 1);
#else
        Name; 
#endif

        public bool IsHighQuality { get; set; }

        public string Name { get; set; }

        public float Size { get; set; }

        public bool ShouldKeep(INamedItem item) { return FishName.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase) || FishNames.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase); }
    }
}