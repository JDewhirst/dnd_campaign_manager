using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaignManagerData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //GenerateTerrainDetails();
            GenerateProvinces();
            using (var db = new DnDCampaignManagerContext())
            {
                var pQuery = db.Provinces.ToList();
                pQuery.ForEach(p => Console.WriteLine(p));
            }
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
                        TerrainId = "Plain"
                    },
                new Province()
                    {
                        Coordinates = 3,
                        ObviousFeature = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.",
                        HiddenFeature = "Dwarvern workshop at Scafell Pike",
                        ProvinceName = "Cumbria",
                        TerrainId = "Mountain"
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
