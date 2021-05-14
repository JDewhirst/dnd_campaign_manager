using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;
using System.Collections.Generic;

namespace DnDCampaignManagerTests
{
    public class ProvinceManagerTests
    {
        ProvinceManager _provinceManager;
        [SetUp]
        public void Setup()
        {
            _provinceManager = new ProvinceManager();
            // remove test entry in DB if present
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedProvinces = db.Provinces.Where(p => p.ProvinceName == "Atlantis");
                db.Provinces.RemoveRange(selectedProvinces);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenProvinceObviousFeatureIsUpdated_ItIsUpdated()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            _provinceManager.UpdateObviousFeatureDescription("Atlantis", "The endless swells of the Atlantic are the terrain only of the foolhardy");
            string result;
            using (var db = new DnDCampaignManagerContext())
            {
                result = db.Provinces.Where(p => p.ProvinceName == "Atlantis").FirstOrDefault().ObviousFeature;
            }
            Assert.AreEqual("The endless swells of the Atlantic are the terrain only of the foolhardy", result);
        }

        [Test]
        public void WhenProvinceHiddenFeatureIsUpdated_ItIsUpdated()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            _provinceManager.UpdateHiddenFeatureDescription("Atlantis", "Atlantis is a myth you fool");
            string result;
            using (var db = new DnDCampaignManagerContext())
            {
                result = db.Provinces.Where(p => p.ProvinceName == "Atlantis").FirstOrDefault().HiddenFeature;
            }
            Assert.AreEqual("Atlantis is a myth you fool", result);
        }

        [Test]
        public void WhenGetRandomEncounterDetailsFromProvinceWithNone_ReturnNoTableInAllFields()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            List<object> result;
            result = _provinceManager.GetProvinceRandomEncounterDetails("Atlantis");
            Assert.AreEqual(new List<object>() { "No Table", "No Table", "No Table" }, result);
        }

        [Test]
        public void GetProvinceHiddenFeature_ReturnsCorrectFeature()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            var result = _provinceManager.GetProvinceHiddenFeature("Atlantis");
            Assert.AreEqual("Holy cow! An underwater city", result);

        }

        [Test] 
        public void GetProvinceObviousFeature_ReturnsCorrectFeature()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            var result = _provinceManager.GetProvinceObviousFeature("Atlantis");
            Assert.AreEqual("It's just some ocean", result);

        }

        [Test]
        public void GetProvinceTravelSpeed_ReturnsCorrectTravelSpeed()
        {
            Province newProvince = new Province() { Coordinates = 111, ProvinceName = "Atlantis", ObviousFeature = "It's just some ocean", HiddenFeature = "Holy cow! An underwater city", TerrainId = "Plain" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.Provinces.Add(newProvince);
                db.SaveChanges();
            }
            var result = _provinceManager.GetProvinceTravelSpeed("Atlantis");
            Assert.AreEqual("1", result);


        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedProvinces = db.Provinces.Where(p => p.ProvinceName == "Atlantis");
                db.Provinces.RemoveRange(selectedProvinces);
                db.SaveChanges();
            }
        }
    }
}