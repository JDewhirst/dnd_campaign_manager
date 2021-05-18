using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaignManagerData
{
    class Program
    {
        static void Main(string[] args)
        {
            /// These functions populate the database, you must run GenerateTerrainDetails and GenerateRandomEncounters
            /// prior to GenerateProvinces, since the provinces include foreign keys that reference TerrainDetails and RandomEncounters
            //GenerateTerrainDetails();
            GenerateRandomEncounters();
            GenerateProvinces();
            
               
        }

        public static void GenerateTerrainDetails()
        {
            var plain = new TerrainDetail()
            {
                TerrainId = "Plain",
                TerrainDescription = "Something about the great ocean of grass",
                TerrainTravelSpeed = 1
            };

            var forest = new TerrainDetail()
            {
                TerrainId = "Forest",
                TerrainDescription = "Great corridors of towering oak loom all around",
                TerrainTravelSpeed = 2
            };

            var hill = new TerrainDetail()
            {
                TerrainId = "Hill",
                TerrainDescription = "The hills have eyes - common Andal saying",
                TerrainTravelSpeed = 2
            };

            var urban = new TerrainDetail()
            {
                TerrainId = "Urban",
                TerrainDescription = "Where people gather there is trade, celebration, deprivation, and intrigue",
                TerrainTravelSpeed = 1
            };

            var mountain = new TerrainDetail()
            {
                TerrainId = "Mountain",
                TerrainDescription = "As majestic as they may be each mountain is but a pale immitation of the glorious Kero Fin.",
                TerrainTravelSpeed = 3
            };

            using (var db = new DnDCampaignManagerContext())
            {
                db.TerrainDetails.Add(plain);
                db.TerrainDetails.Add(forest);
                db.TerrainDetails.Add(hill);
                db.TerrainDetails.Add(urban);
                db.TerrainDetails.Add(mountain);

                db.SaveChanges();
            }

            using (var db = new DnDCampaignManagerContext())
            {
                var terrainQuery = db.TerrainDetails.ToList();
                terrainQuery.ForEach(t => Console.WriteLine(t.TerrainDescription));
            }
        }

        public static void GenerateRandomEncounters()
        {
            List<RandomEncounter> randomEncounters = new List<RandomEncounter>()
            { 
                new RandomEncounter(){RandEncounterTableId = "Creepy Wood", Dice = "2d4", RandEncounter = @"{ '2':'Gang of Goblins', '3':'Bandits', '4':'Wolves', '5':'Bandits', '6':'Bandits', '7':'Bandits', '8':'Will o the Wisp' }"},
                new RandomEncounter(){RandEncounterTableId = "Boring Plain", Dice = "1d6", RandEncounter = @"{ '1':'Herd of Auroch', '2':'Band of Knights', '3':'Merchant Caravan', '4':'Razorgrass', '5':'Orcish raiders', '6':'Bandits'}"},
                new RandomEncounter(){RandEncounterTableId = "Town", Dice = "1d4", RandEncounter = @"{ '1':'Giant Rat', '2':'Pickpocket', '3':'Guards', '4':'Priest' }"}
            };
            
            using (var db = new DnDCampaignManagerContext())
            {
                randomEncounters.ForEach(re => db.RandomEncounters.Add(re));
                db.SaveChanges();
            }

        }

        public static void GenerateProvinces()
        {
            List<Province> provinceList = new List<Province>
            {
                new Province()
                    {
                        Coordinates = 0,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Borderers Raiding encampment",
                        ProvinceName = "Northumberland",
                        TerrainId = "Hill"
                    },
                new Province()
                    {
                        Coordinates = 1,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "The tomb of Sir Gawain",
                        ProvinceName = "Surrey",
                        TerrainId = "Hill"
                    },
                new Province()
                    {
                        Coordinates = 2,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "The ancient crown of the east saxons is kept under heavy guard in the treasury of Sir Ralph fitz Morgan",
                        ProvinceName = "Kent",
                        TerrainId = "Plain",
                        RandEncounterTableId = "Boring Plain"
                    },
                new Province()
                    {
                        Coordinates = 3,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Dwarvern workshop at Scafell Pike",
                        ProvinceName = "Cumbria",
                        TerrainId = "Mountain"
                    },
                new Province()
                    {
                        Coordinates = 4,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Hidden shrine to Asmodeus in the mausoleum",
                        ProvinceName = "Oxford",
                        TerrainId = "Urban",
                        RandEncounterTableId = "Town"
                    },
                new Province()
                    {
                        Coordinates = 5,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Fairy Ring which leads to the realm of Springheel Jack",
                        ProvinceName = "BlackForest",
                        TerrainId = "Forest",
                        RandEncounterTableId = "Creepy Wood"
                    },
                new Province()
                    {
                        Coordinates = 6,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Hag coven",
                        ProvinceName = "RedForest",
                        TerrainId = "Forest",
                        RandEncounterTableId = "Creepy Wood"
                    },
                new Province()
                    {
                        Coordinates = 7,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Settlement of giants",
                        ProvinceName = "BigMount",
                        TerrainId = "Mountain",
                    },
                new Province()
                    {
                        Coordinates = 8,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "",
                        ProvinceName = "SmallMount",
                        TerrainId = "Mountain",
                    },
                new Province()
                    {
                        Coordinates = 9,
                        ObviousFeature = "Maurading band of Goblins, one for each colour of the rainbow",
                        HiddenFeature = "Pot of gold at the end of the rainbow",
                        ProvinceName = "RainbowValley",
                        TerrainId = "Hill",
                    },

        };

            using (var db = new DnDCampaignManagerContext())
            {
                provinceList.ForEach(p => db.Provinces.Add(p));
                db.SaveChanges();
            }
        }

    }
}
