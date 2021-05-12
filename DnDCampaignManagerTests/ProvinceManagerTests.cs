using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;

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
                var selectedProvinces = db.Provinces.Where(p => p.ProvinceName == "Atlantis").FirstOrDefault();
                db.Provinces.RemoveRange(selectedProvinces);
                db.SaveChanges();
            }
        }


        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedProvinces = db.Provinces.Where(p => p.ProvinceName == "Atlantis").FirstOrDefault();
                db.Provinces.RemoveRange(selectedProvinces);
                db.SaveChanges();
            }
        }
    }
}