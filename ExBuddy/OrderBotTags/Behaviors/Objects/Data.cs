namespace ExBuddy.OrderBotTags.Behaviors.Objects
{
    using Clio.Utilities;
    using ExBuddy.GameObjects.Npcs;
    using ExBuddy.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Data
    {
        public static readonly Dictionary<Locations, IList<INpc>> NpcMap = new Dictionary<Locations, IList<INpc>>
        {
            {
                Locations.Eulmore,
                new INpc[]
                {
                    new MasterPieceSupply
                    {
                        AetheryteId = 134,
                        ZoneId = 820,
                        Location = new Vector3("20.03503, 82.05, -19.66895"),
                        NpcId = 1027542
                    },
                    new ShopExchangeCurrency
                    {
                        AetheryteId = 134,
                        ZoneId = 820,
                        Location = new Vector3("17.62415, 82.05, -22.2019"),
                        NpcId = 1027541
                    }
                }
            },
            {
                Locations.RhalgrsReach,
                new INpc[]
                {
                    new MasterPieceSupply
                    {
                        AetheryteId = 104,
                        ZoneId = 635,
                        Location = new Vector3("-67.31707, 0.00999999, 63.22319"),
                        NpcId = 1019457
                    },
                    new ShopExchangeCurrency
                    {
                        AetheryteId = 104,
                        ZoneId = 635,
                        Location = new Vector3("-69.34832, 0.00999999, 61.97374"),
                        NpcId = 1019458
                    }
                }
            },
            {
                Locations.Idyllshire,
                new INpc[]
                {
                    new MasterPieceSupply
                    {
                        AetheryteId = 75,
                        ZoneId = 478,
                        Location = new Vector3("-18.51838, 206.4994, 49.47974"),
                        NpcId = 1012300
                    },
                    new ShopExchangeCurrency
                    {
                        AetheryteId = 75,
                        ZoneId = 478,
                        Location = new Vector3("-20.7711, 206.4994, 51.29588"),
                        NpcId = 1012301
                    }
                }
            },
            {
                Locations.MorDhona,
                new INpc[]
                {
                    new MasterPieceSupply
                    {
                        AetheryteId = 24,
                        ZoneId = 156,
                        Location = new Vector3("50.33948, 31.13618, -737.4532"),
                        NpcId = 1013396
                    },
                    new ShopExchangeCurrency
                    {
                        AetheryteId = 24,
                        ZoneId = 156,
                        Location = new Vector3("47.34875, 31.15659, -737.4838"),
                        NpcId = 1013397
                    }
                }
            },
            {
                Locations.UldahStepsOfNald,
                new INpc[]
                {
                    new FreeCompanyChest
                    {
                        AetheryteId = 9,
                        ZoneId = 130,
                        Location = new Vector3("-149.3096, 4.53186, -91.38635"),
                        NpcId = 2000470,
                        Name = "Company Chest"
                    }
                }
            },
            {
                Locations.LimsaLominsaLowerDecks,
                new INpc[]
                {
                    new FreeCompanyChest
                    {
                        AetheryteId = 8,
                        ZoneId = 129,
                        Location = new Vector3("-200, 17.04425, 58.76245"),
                        NpcId = 2000470,
                        Name = "Company Chest"
                    }
                }
            }
        };

        public static readonly Dictionary<ShopItem, ShopItemInfo> ShopItemMap = new Dictionary<ShopItem, ShopItemInfo>
        {
#if RB_CN

            #region YellowCrafter50

            {
                ShopItem.SoulOfTheCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SoulOfTheCrafter,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 10336,
                    Cost = 400,
                    Yield = 1
                }
            },
            {
                ShopItem.CommercialEngineeringManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommercialEngineeringManual,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12667,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.CrpDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrpDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12659,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.BsmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BsmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12660,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.ArmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ArmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12661,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.GsmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GsmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12662,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.LtwDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LtwDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12663,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.WvrDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WvrDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12664,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.AlcDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AlcDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12665,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.CulDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CulDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12666,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5702,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5703,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5707,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5708,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5712,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5713,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.OnHighOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OnHighOrchestrionRoll,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 21281,
                    Cost = 400,
                    Yield = 1
                }
            },

            #endregion YellowCrafter50

            #region YellowCrafter58

            {
                ShopItem.BlueCrafterToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueCrafterToken - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12839,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GoblinCup,
                new ShopItemInfo
                {
                    Index = 100 + (int) ShopItem.GoblinCup - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14104,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.MoonbeamSilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MoonbeamSilk - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12934,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.MoonbeamSilkHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MoonbeamSilkHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12934,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.SkyspringWater,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SkyspringWater - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12633,
                    Cost = 50,
                    Yield = 3
                }
            },
            {
                ShopItem.SkyspringWaterHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SkyspringWaterHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12633,
                    Cost = 75,
                    Yield = 3
                }
            },
            {
                ShopItem.DryadSap,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DryadSap - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12933,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.DryadSapHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DryadSapHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12933,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.OdorlessAnimalFat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OdorlessAnimalFat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12935,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.OdorlessAnimalFatHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OdorlessAnimalFatHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12935,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.PurifiedCoke,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PurifiedCoke - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12931,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.PurifiedCokeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PurifiedCokeHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12931,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.Raziqcoat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Raziqcoat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12932,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.RaziqcoatHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RaziqcoatHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12932,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.SweetCreamMilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SweetCreamMilk - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16734,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.SweetCreamMilkHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SweetCreamMilkHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16734,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneCheese,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneCheese - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16735,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneCheeseHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneCheeseHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16735,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavensEgg,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavensEgg - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 15652,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavensEggHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavensEggHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 15652,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.CarbonFiber,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarbonFiber - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 5339,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CarbonFiberHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarbonFiberHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 5339,
                    Cost = 62,
                    Yield = 1
                }
            },
            {
                ShopItem.LoaghtanFilet,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LoaghtanFilet - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14145,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.LoaghtanFiletHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LoaghtanFiletHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14145,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldenApple,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldenApple - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14142,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldenAppleHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldenAppleHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14142,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.SolsticeGarlic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SolsticeGarlic - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14143,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.SolsticeGarlicHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SolsticeGarlicHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14143,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.MatureOliveOil,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MatureOliveOil - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14144,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.MatureOliveOilHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MatureOliveOilHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14144,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.PowderedMermanHorn,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PowderedMermanHorn - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14937,
                    Cost = 6,
                    Yield = 1
                }
            },
            {
                ShopItem.PowderedMermanHornHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PowderedMermanHornHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14937,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavenlyKukuruPowder,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavenlyKukuruPowder - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12886,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavenlyKukuruPowderHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavenlyKukuruPowderHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12886,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.BouillonCube,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BouillonCube - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12905,
                    Cost = 4,
                    Yield = 1
                }
            },
            {
                ShopItem.BouillonCubeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BouillonCubeHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12905,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalSoySauce,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalSoySauce - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12906,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalSoySauceHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalSoySauceHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12906,
                    Cost = 37,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalMisoPaste,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalMisoPaste - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12907,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalMisoPasteHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalMisoPasteHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12907,
                    Cost = 37,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsHat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsHat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11958,
                    Cost = 60,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsGown,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsGown - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11963,
                    Cost = 135,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsGloves,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsGloves - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11968,
                    Cost = 60,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsHose,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsHose - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11976,
                    Cost = 52,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsThighboots,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsThighboots - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11981,
                    Cost = 52,
                    Yield = 1
                }
            },

            #endregion YellowCrafter58

            #region YellowCrafter61

            {
                ShopItem.DomanIronHalfheartSaw,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHalfheartSaw - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19527,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronClawHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronClawHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19538,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronLumpHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronLumpHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19528,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronFile,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronFile - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19539,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronRaisingHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronRaisingHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19529,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronPliers,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronPliers - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19540,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DuriumTextureHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DuriumTextureHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19530,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.SlateGrindingWheel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SlateGrindingWheel - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19541,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronHeadKnife,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHeadKnife - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19531,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronAwl,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronAwl - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19542,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DzoHornNeedle,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DzoHornNeedle - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19532,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.PineSpinningWheel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PineSpinningWheel - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19543,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronAlembic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronAlembic - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19533,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronMortar,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronMortar - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19544,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronFrypan,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronFrypan - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19534,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronCulinaryKnife,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronCulinaryKnife - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19545,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCapofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCapofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19632,
                    Cost = 110,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuRobeofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuRobeofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19633,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DuriumChaplets,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DuriumChaplets - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19634,
                    Cost = 110,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCulottesofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCulottesofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19635,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinBootsofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinBootsofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19636,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowCrafter61

            #region YellowCrafter70

            {
                ShopItem.ReunionCheese,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ReunionCheese - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24282,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.KoshuPork,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KoshuPork - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 19876,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DzoSirloin,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DzoSirloin - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22438,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanRice,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanRice - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22439,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.TeaBrick,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TeaBrick - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 19840,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.CrimsonPepper,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrimsonPepper - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21301,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RooibosLeaves,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RooibosLeaves - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24281,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.SecretRecipeBroth,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SecretRecipeBroth - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21089,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.HoneydewHoney,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HoneydewHoney - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22446,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.WoolTopCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoolTopCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16906,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.FlannelCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FlannelCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 17574,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.NewWorldMacrameCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.NewWorldMacrameCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16907,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GyrAbanianAlchemic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GyrAbanianAlchemic - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21082,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.PellitoryCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PellitoryCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 15945,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18025,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25194,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18026,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25195,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18027,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25196,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.RevisedEngineeringManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RevisedEngineeringManual - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 26554,
                    Cost = 300,
                    Yield = 1
                }
            },
            {
                ShopItem.PastryCupboard,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PastryCupboard - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24518,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.FabricRack,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FabricRack - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24520,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.PotionRack,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PotionRack - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24521,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.KingcraftDemimateria,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KingcraftDemimateria - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 23181,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.AfterglowOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AfterglowOrchestrionRoll - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25062,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.HarmonyOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HarmonyOrchestrionRoll - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25066,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.MetalWorkLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MetalWorkLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27303,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.WoodenWorkLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoodenWorkLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27304,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.AlchemicalLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AlchemicalLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27305,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowCrafter70

            #region WhiteCrafter80

            {
                ShopItem.CompetenceVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26735,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26736,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26737,
                    Cost = 500,
                    Yield = 1
                }
            },

            #endregion WhiteCrafter80

            #region YellowGatherer50

            {
                ShopItem.HiCordial,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HiCordial - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12669,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.CommercialSurvivalManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommercialSurvivalManual - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12668,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.BruteLeech,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BruteLeech - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12711,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.RedBalloon,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RedBalloon - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12708,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.GiantCraneFly,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GiantCraneFly - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12712,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.MagmaWorm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MagmaWorm - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12709,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.FiendWorm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FiendWorm - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12710,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5687,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5688,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5692,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5693,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5697,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5698,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GardenGravel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GardenGravel - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 23898,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.SongsofSaltandSufferingOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SongsofSaltandSufferingOrchestrionRoll - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 21282,
                    Cost = 400,
                    Yield = 1
                }
            },

            #endregion YellowGatherer50

            #region YellowGatherer58

            {
                ShopItem.BlueGatherToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueGatherToken - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12841,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GoblinDice,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoblinDice - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14105,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersScarf,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersScarf - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11986,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersVest,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersVest - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11991,
                    Cost = 135,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersWristguards,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersWristguards - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11996,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersSlops,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersSlops - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12004,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersShoes,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersShoes - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12009,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.CrownTrout,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrownTrout - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13737,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.CrownTroutHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrownTroutHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13737,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.RetributionStaff,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RetributionStaff - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13738,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RetributionStaffHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RetributionStaffHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13738,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.ThiefBetta,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ThiefBetta - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13739,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.ThiefBettaHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ThiefBettaHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13739,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldsmithCrab,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldsmithCrab - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13740,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldsmithCrabHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldsmithCrabHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13740,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.Pterodactyl,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Pterodactyl - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13733,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.PterodactylHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PterodactylHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13733,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.Eurhinosaur,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Eurhinosaur - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13734,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.EurhinosaurHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EurhinosaurHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13734,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GemMarimo,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GemMarimo - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13736,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.GemMarimoHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GemMarimoHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13736,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.Sphalerite,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Sphalerite - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13750,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.SphaleriteHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SphaleriteHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13750,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.WindSilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WindSilk - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13744,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.CloudCottonBoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CloudCottonBoll - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13753,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.CloudCottonBollHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CloudCottonBollHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13753,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.DinosaurLeather,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DinosaurLeather - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13745,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.RoyalMistletoe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RoyalMistletoe - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13752,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RoyalMistletoeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RoyalMistletoeHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13752,
                    Cost = 25,
                    Yield = 1
                }
            },

            #endregion YellowGatherer58

            #region YellowGatherer61

            {
                ShopItem.FolkloreGatherToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FolkloreGatherToken - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20260,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronPickaxe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronPickaxe - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19535,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronSledgehammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronSledgehammer - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19546,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronHatchet,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHatchet - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19536,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronScythe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronScythe - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19547,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.PineFishingRod,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PineFishingRod - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19537,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinCapofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinCapofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19637,
                    Cost = 180,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCoatofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCoatofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19638,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinFingerlessGlovesofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinFingerlessGlovesofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19639,
                    Cost = 120,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCulottesofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCulottesofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19640,
                    Cost = 90,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinBootsofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinBootsofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19641,
                    Cost = 90,
                    Yield = 1
                }
            },
            {
                ShopItem.Silkworm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Silkworm - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20616,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.BreamLure,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BreamLure - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20618,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.SuspendingMinnow,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SuspendingMinnow - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20619,
                    Cost = 30,
                    Yield = 1
                }
            },

            #endregion YellowGatherer61

            #region YellowGatherer70

            {
                ShopItem.WoolTopGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoolTopGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16906,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.FlannelGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FlannelGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 17574,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.NewWorldMacrameGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.NewWorldMacrameGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16907,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.PellitoryGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PellitoryGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 15945,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.DusklightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DusklightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20013,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DusklightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DusklightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20013,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.DawnlightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DawnlightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20014,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DawnlightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DawnlightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20014,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbrightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbrightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20015,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbrightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbrightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20015,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbornAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbornAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20016,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbornAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbornAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20016,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.EverdeepAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverdeepAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20017,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverdeepAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverdeepAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20017,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18022,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25191,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18023,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25192,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18024,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25193,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.RegionalFolkloreTradeToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RegionalFolkloreTradeToken - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27985,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.RevisedSurvivalManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RevisedSurvivalManual - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 26553,
                    Cost = 300,
                    Yield = 1
                }
            },
            {
                ShopItem.ChocoboRaincoat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChocoboRaincoat - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21925,
                    Cost = 1650,
                    Yield = 1
                }
            },
            {
                ShopItem.FruitStall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FruitStall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24516,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.VegetableStall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.VegetableStall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24517,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.MineralDisplay,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MineralDisplay - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24519,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.CarpetofFlowers,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarpetofFlowers - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27298,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.HopeForgottenOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HopeForgottenOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25063,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.TheStoneRemembersOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TheStoneRemembersOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25064,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.OldWoundsOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OldWoundsOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25065,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.RobberBall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RobberBall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27587,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.JerkedOvim,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.JerkedOvim - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27586,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.ShortBillMinnow,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ShortBillMinnow - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27588,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.BlueBobbit,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueBobbit - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20676,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneflyLarva,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneflyLarva - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20675,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.Firebloom,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Firebloom - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27316,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.SeastoneBrazier,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SeastoneBrazier - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27317,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowGatherer70

            #region WhiteGatherer80
            
            {
                ShopItem.ChiaroglowAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChiaroglowAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27811,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.ChiaroglowAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChiaroglowAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27811,
                    Cost = 130,
                    Yield = 1
                }
            },
            {
                ShopItem.ScuroglowAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ScuroglowAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27812,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.ScuroglowAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ScuroglowAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27812,
                    Cost = 130,
                    Yield = 1
                }
            },
            {
                ShopItem.AgedeepAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgedeepAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27813,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgedeepAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgedeepAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27813,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.AgewoodAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgewoodAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27814,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgewoodAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgewoodAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27814,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.AgeflawAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgeflawAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27815,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgeflawAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgeflawAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27815,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26732,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26733,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26734,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.SquidStrip,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SquidStrip - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27590,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.Baitbugs,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Baitbugs - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27589,
                    Cost = 5,
                    Yield = 1
                }
            },

            #endregion WhiteCrafter80
#else

            #region YellowCrafter50

            {
                ShopItem.SoulOfTheCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SoulOfTheCrafter,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 10336,
                    Cost = 400,
                    Yield = 1
                }
            },
            {
                ShopItem.CommercialEngineeringManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommercialEngineeringManual,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12667,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.CrpDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrpDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12659,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.BsmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BsmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12660,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.ArmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ArmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12661,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.GsmDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GsmDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12662,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.LtwDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LtwDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12663,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.WvrDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WvrDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12664,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.AlcDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AlcDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12665,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.CulDelineation,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CulDelineation,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12666,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5702,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5703,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5707,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5708,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandIV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5712,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandV,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5713,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.OnHighOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OnHighOrchestrionRoll,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow50,
                    ItemId = 21281,
                    Cost = 400,
                    Yield = 1
                }
            },

            #endregion YellowCrafter50

            #region YellowCrafter58

            {
                ShopItem.BlueCrafterToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueCrafterToken - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12839,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GoblinCup,
                new ShopItemInfo
                {
                    Index = 100 + (int) ShopItem.GoblinCup - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14104,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.MoonbeamSilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MoonbeamSilk - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12934,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.MoonbeamSilkHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MoonbeamSilkHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12934,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.SkyspringWater,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SkyspringWater - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12633,
                    Cost = 50,
                    Yield = 3
                }
            },
            {
                ShopItem.SkyspringWaterHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SkyspringWaterHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12633,
                    Cost = 75,
                    Yield = 3
                }
            },
            {
                ShopItem.DryadSap,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DryadSap - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12933,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.DryadSapHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DryadSapHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12933,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.OdorlessAnimalFat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OdorlessAnimalFat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12935,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.OdorlessAnimalFatHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OdorlessAnimalFatHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12935,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.PurifiedCoke,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PurifiedCoke - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12931,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.PurifiedCokeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PurifiedCokeHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12931,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.Raziqcoat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Raziqcoat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12932,
                    Cost = 50,
                    Yield = 5
                }
            },
            {
                ShopItem.RaziqcoatHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RaziqcoatHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12932,
                    Cost = 75,
                    Yield = 5
                }
            },
            {
                ShopItem.SweetCreamMilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SweetCreamMilk - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16734,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.SweetCreamMilkHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SweetCreamMilkHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16734,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneCheese,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneCheese - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16735,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneCheeseHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneCheeseHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 16735,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavensEgg,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavensEgg - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 15652,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavensEggHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavensEggHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 15652,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.CarbonFiber,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarbonFiber - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 5339,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.CarbonFiberHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarbonFiberHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 5339,
                    Cost = 62,
                    Yield = 1
                }
            },
            {
                ShopItem.LoaghtanFilet,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LoaghtanFilet - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14145,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.LoaghtanFiletHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.LoaghtanFiletHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14145,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldenApple,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldenApple - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14142,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldenAppleHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldenAppleHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14142,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.SolsticeGarlic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SolsticeGarlic - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14143,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.SolsticeGarlicHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SolsticeGarlicHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14143,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.MatureOliveOil,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MatureOliveOil - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14144,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.MatureOliveOilHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MatureOliveOilHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14144,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.PowderedMermanHorn,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PowderedMermanHorn - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14937,
                    Cost = 6,
                    Yield = 1
                }
            },
            {
                ShopItem.PowderedMermanHornHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PowderedMermanHornHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14937,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavenlyKukuruPowder,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavenlyKukuruPowder - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12886,
                    Cost = 8,
                    Yield = 1
                }
            },
            {
                ShopItem.HeavenlyKukuruPowderHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HeavenlyKukuruPowderHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12886,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.BouillonCube,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BouillonCube - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12905,
                    Cost = 4,
                    Yield = 1
                }
            },
            {
                ShopItem.BouillonCubeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BouillonCubeHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12905,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalSoySauce,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalSoySauce - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12906,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalSoySauceHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalSoySauceHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12906,
                    Cost = 37,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalMisoPaste,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalMisoPaste - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12907,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.OrientalMisoPasteHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OrientalMisoPasteHq - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12907,
                    Cost = 37,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsHat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsHat - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11958,
                    Cost = 60,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsGown,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsGown - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11963,
                    Cost = 135,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsGloves,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsGloves - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11968,
                    Cost = 60,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsHose,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsHose - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11976,
                    Cost = 52,
                    Yield = 1
                }
            },
            {
                ShopItem.AdeptsThighboots,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AdeptsThighboots - 200,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11981,
                    Cost = 52,
                    Yield = 1
                }
            },

            #endregion YellowCrafter58

            #region YellowCrafter61

            {
                ShopItem.DomanIronHalfheartSaw,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHalfheartSaw - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19527,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronClawHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronClawHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19538,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronLumpHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronLumpHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19528,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronFile,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronFile - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19539,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronRaisingHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronRaisingHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19529,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronPliers,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronPliers - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19540,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DuriumTextureHammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DuriumTextureHammer - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19530,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.SlateGrindingWheel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SlateGrindingWheel - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19541,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronHeadKnife,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHeadKnife - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19531,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronAwl,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronAwl - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19542,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DzoHornNeedle,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DzoHornNeedle - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19532,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.PineSpinningWheel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PineSpinningWheel - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19543,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronAlembic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronAlembic - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19533,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronMortar,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronMortar - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19544,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronFrypan,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronFrypan - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19534,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronCulinaryKnife,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronCulinaryKnife - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19545,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCapofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCapofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19632,
                    Cost = 110,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuRobeofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuRobeofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19633,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DuriumChaplets,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DuriumChaplets - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19634,
                    Cost = 110,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCulottesofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCulottesofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19635,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinBootsofCrafting,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinBootsofCrafting - 400,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19636,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowCrafter61

            #region YellowCrafter70

            {
                ShopItem.ReunionCheese,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ReunionCheese - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24282,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.KoshuPork,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KoshuPork - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 19876,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DzoSirloin,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DzoSirloin - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22438,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanRice,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanRice - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22439,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.TeaBrick,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TeaBrick - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 19840,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.CrimsonPepper,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrimsonPepper - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21301,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RooibosLeaves,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RooibosLeaves - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24281,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.SecretRecipeBroth,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SecretRecipeBroth - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21089,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.HoneydewHoney,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HoneydewHoney - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 22446,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.WoolTopCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoolTopCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16906,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.FlannelCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FlannelCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 17574,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.NewWorldMacrameCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.NewWorldMacrameCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16907,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GyrAbanianAlchemic,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GyrAbanianAlchemic - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21082,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.PellitoryCrafter,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PellitoryCrafter - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 15945,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18025,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CompetenceVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25194,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18026,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25195,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVI - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18027,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVII - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25196,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.RevisedEngineeringManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RevisedEngineeringManual - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 26554,
                    Cost = 300,
                    Yield = 1
                }
            },
            {
                ShopItem.PastryCupboard,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PastryCupboard - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24518,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.FabricRack,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FabricRack - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24520,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.PotionRack,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PotionRack - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24521,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.KingcraftDemimateria,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KingcraftDemimateria - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 23181,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.AfterglowOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AfterglowOrchestrionRoll - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25062,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.HarmonyOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HarmonyOrchestrionRoll - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25066,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.MetalWorkLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MetalWorkLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27303,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.WoodenWorkLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoodenWorkLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27304,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.AlchemicalLantern,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AlchemicalLantern - 600,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27305,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowCrafter70

            #region WhiteCrafter80

            {
                ShopItem.CompetenceVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CompetenceVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26735,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.CunningVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CunningVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26736,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.CommandVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommandVIII - 800,
                    ShopJob = ShopJob.Crafter,
                    ShopType = ShopType.White80,
                    ItemId = 26737,
                    Cost = 500,
                    Yield = 1
                }
            },

            #endregion WhiteCrafter80

            #region YellowGatherer50

            {
                ShopItem.HiCordial,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HiCordial - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12669,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.CommercialSurvivalManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CommercialSurvivalManual - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12668,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.BruteLeech,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BruteLeech - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12711,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.RedBalloon,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RedBalloon - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12708,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.GiantCraneFly,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GiantCraneFly - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12712,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.MagmaWorm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MagmaWorm - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12709,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.FiendWorm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FiendWorm - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 12710,
                    Cost = 1,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5687,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5688,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5692,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5693,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspIV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspIV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5697,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspV,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspV - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 5698,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.GardenGravel,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GardenGravel - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 23898,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.SongsofSaltandSufferingOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SongsofSaltandSufferingOrchestrionRoll - 100,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow50,
                    ItemId = 21282,
                    Cost = 400,
                    Yield = 1
                }
            },

            #endregion YellowGatherer50

            #region YellowGatherer58

            {
                ShopItem.BlueGatherToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueGatherToken - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12841,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.GoblinDice,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoblinDice - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 14105,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersScarf,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersScarf - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11986,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersVest,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersVest - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11991,
                    Cost = 135,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersWristguards,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersWristguards - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 11996,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersSlops,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersSlops - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12004,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.TrailblazersShoes,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TrailblazersShoes - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 12009,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.CrownTrout,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrownTrout - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13737,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.CrownTroutHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CrownTroutHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13737,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.RetributionStaff,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RetributionStaff - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13738,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RetributionStaffHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RetributionStaffHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13738,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.ThiefBetta,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ThiefBetta - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13739,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.ThiefBettaHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ThiefBettaHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13739,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldsmithCrab,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldsmithCrab - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13740,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.GoldsmithCrabHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GoldsmithCrabHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13740,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.Pterodactyl,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Pterodactyl - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13733,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.PterodactylHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PterodactylHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13733,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.Eurhinosaur,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Eurhinosaur - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13734,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.EurhinosaurHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EurhinosaurHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13734,
                    Cost = 12,
                    Yield = 1
                }
            },
            {
                ShopItem.GemMarimo,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GemMarimo - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13736,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.GemMarimoHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GemMarimoHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13736,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.Sphalerite,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Sphalerite - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13750,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.SphaleriteHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SphaleriteHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13750,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.WindSilk,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WindSilk - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13744,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.CloudCottonBoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CloudCottonBoll - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13753,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.CloudCottonBollHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CloudCottonBollHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13753,
                    Cost = 25,
                    Yield = 1
                }
            },
            {
                ShopItem.DinosaurLeather,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DinosaurLeather - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13745,
                    Cost = 75,
                    Yield = 1
                }
            },
            {
                ShopItem.RoyalMistletoe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RoyalMistletoe - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13752,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.RoyalMistletoeHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RoyalMistletoeHq - 300,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow58,
                    ItemId = 13752,
                    Cost = 25,
                    Yield = 1
                }
            },

            #endregion YellowGatherer58

            #region YellowGatherer61

            {
                ShopItem.FolkloreGatherToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FolkloreGatherToken - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20260,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronPickaxe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronPickaxe - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19535,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronSledgehammer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronSledgehammer - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19546,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronHatchet,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronHatchet - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19536,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.DomanIronScythe,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DomanIronScythe - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19547,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.PineFishingRod,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PineFishingRod - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19537,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinCapofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinCapofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19637,
                    Cost = 180,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCoatofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCoatofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19638,
                    Cost = 240,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinFingerlessGlovesofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinFingerlessGlovesofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19639,
                    Cost = 120,
                    Yield = 1
                }
            },
            {
                ShopItem.KudzuCulottesofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.KudzuCulottesofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19640,
                    Cost = 90,
                    Yield = 1
                }
            },
            {
                ShopItem.TigerskinBootsofGathering,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TigerskinBootsofGathering - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 19641,
                    Cost = 90,
                    Yield = 1
                }
            },
            {
                ShopItem.Silkworm,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Silkworm - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20616,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.BreamLure,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BreamLure - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20618,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.SuspendingMinnow,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SuspendingMinnow - 500,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow61,
                    ItemId = 20619,
                    Cost = 30,
                    Yield = 1
                }
            },

            #endregion YellowGatherer61

            #region YellowGatherer70

            {
                ShopItem.WoolTopGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.WoolTopGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16906,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.FlannelGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FlannelGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 17574,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.NewWorldMacrameGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.NewWorldMacrameGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 16907,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.PellitoryGatherer,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.PellitoryGatherer - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 15945,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.DusklightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DusklightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20013,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DusklightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DusklightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20013,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.DawnlightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DawnlightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20014,
                    Cost = 10,
                    Yield = 1
                }
            },
            {
                ShopItem.DawnlightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.DawnlightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20014,
                    Cost = 20,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbrightAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbrightAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20015,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbrightAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbrightAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20015,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbornAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbornAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20016,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverbornAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverbornAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20016,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.EverdeepAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverdeepAethersand - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20017,
                    Cost = 15,
                    Yield = 1
                }
            },
            {
                ShopItem.EverdeepAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.EverdeepAethersandHq - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20017,
                    Cost = 30,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18022,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25191,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18023,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25192,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVI,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVI - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 18024,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVII - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25193,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.RegionalFolkloreTradeToken,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RegionalFolkloreTradeToken - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27985,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.RevisedSurvivalManual,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RevisedSurvivalManual - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 26553,
                    Cost = 300,
                    Yield = 1
                }
            },
            {
                ShopItem.ChocoboRaincoat,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChocoboRaincoat - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 21925,
                    Cost = 1650,
                    Yield = 1
                }
            },
            {
                ShopItem.FruitStall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.FruitStall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24516,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.VegetableStall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.VegetableStall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24517,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.MineralDisplay,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.MineralDisplay - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 24519,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.CarpetofFlowers,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.CarpetofFlowers - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27298,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.HopeForgottenOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.HopeForgottenOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25063,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.TheStoneRemembersOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.TheStoneRemembersOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25064,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.OldWoundsOrchestrionRoll,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.OldWoundsOrchestrionRoll - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 25065,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.RobberBall,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.RobberBall - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27587,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.JerkedOvim,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.JerkedOvim - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27586,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.ShortBillMinnow,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ShortBillMinnow - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27588,
                    Cost = 50,
                    Yield = 1
                }
            },
            {
                ShopItem.BlueBobbit,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.BlueBobbit - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20676,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.StoneflyLarva,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.StoneflyLarva - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 20675,
                    Cost = 3,
                    Yield = 1
                }
            },
            {
                ShopItem.Firebloom,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Firebloom - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27316,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.SeastoneBrazier,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SeastoneBrazier - 700,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.Yellow70,
                    ItemId = 27317,
                    Cost = 100,
                    Yield = 1
                }
            },

            #endregion YellowGatherer70

            #region WhiteGatherer80
            
            {
                ShopItem.ChiaroglowAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChiaroglowAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27811,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.ChiaroglowAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ChiaroglowAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27811,
                    Cost = 130,
                    Yield = 1
                }
            },
            {
                ShopItem.ScuroglowAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ScuroglowAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27812,
                    Cost = 100,
                    Yield = 1
                }
            },
            {
                ShopItem.ScuroglowAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.ScuroglowAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27812,
                    Cost = 130,
                    Yield = 1
                }
            },
            {
                ShopItem.AgedeepAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgedeepAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27813,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgedeepAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgedeepAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27813,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.AgewoodAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgewoodAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27814,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgewoodAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgewoodAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27814,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.AgeflawAethersand,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgeflawAethersand - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27815,
                    Cost = 200,
                    Yield = 1
                }
            },
            {
                ShopItem.AgeflawAethersandHq,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.AgeflawAethersandHq - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27815,
                    Cost = 250,
                    Yield = 1
                }
            },
            {
                ShopItem.GuerdonVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuerdonVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26732,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.GuileVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GuileVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26733,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.GraspVIII,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.GraspVIII - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 26734,
                    Cost = 500,
                    Yield = 1
                }
            },
            {
                ShopItem.SquidStrip,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.SquidStrip - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27590,
                    Cost = 5,
                    Yield = 1
                }
            },
            {
                ShopItem.Baitbugs,
                new ShopItemInfo
                {
                    Index = (int) ShopItem.Baitbugs - 900,
                    ShopJob = ShopJob.Gatherer,
                    ShopType = ShopType.White80,
                    ItemId = 27589,
                    Cost = 5,
                    Yield = 1
                }
            },

            #endregion WhiteCrafter80

#endif
        };

        public static IEnumerable<INpc> GetNpcsByLocation(Locations location)
        {
            IList<INpc> npcs;
            if (NpcMap.TryGetValue(location, out npcs))
                return npcs;

            return Enumerable.Empty<INpc>();
        }

        public static IEnumerable<T> GetNpcsByLocation<T>(Locations location) where T : INpc { return GetNpcsByLocation(location).OfType<T>(); }
    }
}