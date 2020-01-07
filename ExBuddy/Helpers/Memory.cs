namespace ExBuddy.Helpers
{
    using System;
    using System.Linq;
    using ff14bot;
    using ff14bot.Managers;
    using ff14bot.NeoProfiles;
    using GreyMagic;
    using Offsets;
    using OrderBotTags.Behaviors.Objects;

    public static class Memory
    {
        public static class Request
        {
            public static uint ItemId1 => GetItemByIndex(0);

            public static uint ItemId2 => GetItemByIndex(1);

            public static uint ItemId3 => GetItemByIndex(2);

            public static uint[] ItemsToTurnIn { get { return new[] {Request.ItemId1, Request.ItemId2, Request.ItemId3}.Where(i => i > 0).ToArray(); } }

            public static uint GetItemByIndex(int index)
            {
                var ptr = RequestOffsets.ItemBasePtr + MarshalCache<IntPtr>.Size;
                return Core.Memory.NoCacheRead<uint>(ptr + RequestOffsets.ItemSize * index + MarshalCache<IntPtr>.Size);
            }
        }

        public static class Scrips
        {
            public static int RedCrafter => (int) SpecialCurrencyManager.GetCurrencyCount(SpecialCurrency.RedCraftersScrips);

            public static int YellowCrafter => (int) SpecialCurrencyManager.GetCurrencyCount(SpecialCurrency.YellowCraftersScrips);

            public static int RedGatherer => (int) SpecialCurrencyManager.GetCurrencyCount(SpecialCurrency.RedGatherersScrips);

            public static int YellowGatherer => (int) SpecialCurrencyManager.GetCurrencyCount(SpecialCurrency.YellowGatherersScrips);

            public static int CenturioSeals => (int) SpecialCurrencyManager.GetCurrencyCount(SpecialCurrency.CenturioSeals);

            public static int WhiteCrafter => ConditionParser.ItemCount(25199);

            public static int WhiteGatherer => ConditionParser.ItemCount(25200);

            public static int GetRemainingScripsByShopType(ShopJob shopJob, ShopType shopType)
            {
                switch (shopJob)
                {
                    case ShopJob.Crafter:
                    {
                        switch (shopType)
                        {
                            case ShopType.Yellow50:
                                return Scrips.YellowCrafter;
                            case ShopType.Yellow58:
                                return Scrips.YellowCrafter;
                            case ShopType.Yellow61:
                                return Scrips.YellowCrafter;
                            case ShopType.Yellow70:
                                return Scrips.YellowCrafter;
                            case ShopType.White80:
                                return Scrips.WhiteCrafter;
                        }
                    }
                        break;
                    case ShopJob.Gatherer:
                    {
                        switch (shopType)
                        {
                            case ShopType.Yellow50:
                                return Scrips.YellowGatherer;
                            case ShopType.Yellow58:
                                return Scrips.YellowGatherer;
                            case ShopType.Yellow61:
                                return Scrips.YellowGatherer;
                            case ShopType.Yellow70:
                                return Scrips.YellowGatherer;
                            case ShopType.White80:
                                return Scrips.WhiteGatherer;
                        }
                    }
                        break;
                }

                return 0;
            }
        }
    }
}