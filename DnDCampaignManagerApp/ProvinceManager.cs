using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManagerData;


namespace DnDCampaignManagerApp
{
    public class ProvinceManager
    {
        public Province SelectedProvince { get; set; }
        private RandomEncounterManager _randomEncounterManager = new RandomEncounterManager();

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
                if (SelectedProvince is not null) { SelectedProvince.ObviousFeature = featureText; }
                db.SaveChanges();
            }
        }

        public void UpdateHiddenFeatureDescription(string provinceName, string featureText)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                if (SelectedProvince is not null) { SelectedProvince.HiddenFeature = featureText; } 
                db.SaveChanges();
            }
        }

        public List<object> GetProvinceRandomEncounterDetails(string provinceName)
        {
            string? tableId;
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                if (SelectedProvince is not null)
                {
                    tableId = SelectedProvince.RandEncounterTableId;
                }
                else
                {
                    tableId = null;
                }
                
            }
            if (tableId is not null)
            {
                return _randomEncounterManager.GetTableDetails(tableId);
            }
            else
            {
                return new List<Object>() { "No Table", "No Table", "No Table" };
            }
            
        }

        public void SetRandomEncounterTable(string provinceName, string tableId)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = db.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
                SelectedProvince.RandEncounterTableId = tableId;
                db.SaveChanges();
            }
        }


    }
}
