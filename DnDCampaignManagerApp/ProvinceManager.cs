using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignManagerData;

namespace DnDCampaignManagerApp
{
    public class ProvinceManager
    {
        public Province SelectedProvince { get; set; }
        private TerrainManager _terrainManager = new TerrainManager();

        public void SetSelectedProvince(object selectedItem)
        {
            SelectedProvince = (Province)selectedItem;
        }

        public int GetNumberOfProvinces()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                return db.Provinces.Count();
            }
        }

        public List<Province> GetAllProvincesQuery()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                return db.Provinces.ToList();
            }
        }

        public string GetProvinceHiddenFeature(string provinceName)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                return SelectedProvince.HiddenFeature;
            }
        }

        public string GetProvinceObviousFeature(string provinceName)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                return SelectedProvince.ObviousFeature;
            }
        }

        public string GetProvinceTravelSpeed(string provinceName)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var provinceTerrain = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                var provinceTravelSpeed = db.TerrainDetails.Where(td => td.TerrainId == provinceTerrain.TerrainId)
                    .FirstOrDefault().TerrainTravelSpeed.ToString();
                return provinceTravelSpeed;
            }
        }

        public void UpdateObviousFeatureDescription(string provinceName, string featureText)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                SelectedProvince.ObviousFeature = featureText;
                db.SaveChanges();
            }
        }

        public void UpdateHiddenFeatureDescription(string provinceName, string featureText)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                SelectedProvince.HiddenFeature = featureText;
                db.SaveChanges();
            }
        }
    }
}
