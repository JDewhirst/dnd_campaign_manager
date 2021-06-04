using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;

namespace DnDCampaignManagerTests
{
    public class TerrainManagerTests
    {
        TerrainManager _terrainManager;
        [SetUp]
        public void Setup()
        {
            _terrainManager = new TerrainManager();
            // remove test entry in DB if present
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedTerrain = db.TerrainDetails.Where(t => t.TerrainId == "Martian");
                db.TerrainDetails.RemoveRange(selectedTerrain);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenNewTerrainIsAdded_TheNumberOfTerrainIncreasesBy1()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var numTerrains = db.TerrainDetails.Count();
                _terrainManager.CreateTerrain("Martian", "A barren red wasteland", 4);
                var result = db.TerrainDetails.Count();
                Assert.AreEqual(1, result - numTerrains);
            }
        }


        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedTerrain = db.TerrainDetails.Where(t => t.TerrainId == "Martian");
                db.TerrainDetails.RemoveRange(selectedTerrain);
                db.SaveChanges();
            }
        }
    }
}