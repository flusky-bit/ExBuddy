namespace ExBuddy.OrderBotTags.Behaviors.Objects
{
    using ff14bot.Managers;

    public struct ShopItemInfo
    {
        public ushort Cost { get; set; }

        public uint Index { get; set; }

        public Item ItemData => DataManager.ItemCache[ItemId];

        public uint ItemId { get; set; }

        public ShopType ShopType { get; set; }

        public ShopJob ShopJob { get; set; }

        public byte Yield { get; set; }
    }
}