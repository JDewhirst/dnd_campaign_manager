using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CampaignManagerData;
using System.Diagnostics;

namespace DnDCampaignManagerApp
{
    public class ProvinceManager
    {
        public Province SelectedProvince { get; set; }
        private IProvinceService _service;
        private RandomEncounterManager _randomEncounterManager = new RandomEncounterManager();
        
        public ProvinceManager()
        {
            _service = new ProvinceService();
        }

        public ProvinceManager(IProvinceService service)
        {
            _service = service ?? throw new ArgumentException("Province service cannot be null");
        }

        public void SetSelectedProvince(object selectedItem)
        {
            SelectedProvince = (Province)selectedItem;
        }

        public void CreateProvince(int coordinates, string provinceName, string terrainId, string obviousFeature = null, string hiddenFeature = null)
        {
            var newProvince = new Province()
            {
                Coordinates = coordinates,
                ProvinceName = provinceName,
                TerrainId = terrainId,
                ObviousFeature = obviousFeature,
                HiddenFeature = hiddenFeature
            };
            _service.CreateProvince(newProvince);
        }

        public int GetNumberOfProvinces()
        {
            return _service.GetNumberOfProvinces();
        }

        public List<Province> GetAllProvincesQuery()
        {
            return _service.GetAllProvincesQuery();
        }

        public string GetProvinceHiddenFeature(string provinceName)
        {
            return _service.GetProvinceByName(provinceName).HiddenFeature;
        }

        public string GetProvinceObviousFeature(string provinceName)
        {
            return _service.GetProvinceByName(provinceName).ObviousFeature;
        }

        public string GetProvinceTravelSpeed(string provinceName)
        {
            SelectedProvince = _service.GetProvinceByName(provinceName);
            return _service.GetTravelSpeed(SelectedProvince.TerrainId);
        }

        public bool UpdateObviousFeatureDescription(string provinceName, string featureText)
        {
            SelectedProvince = _service.GetProvinceByName(provinceName);
            if (SelectedProvince == null)
            {
                Debug.WriteLine($"Can't find province: {provinceName}");
                return false;
            }
            SelectedProvince.ObviousFeature = featureText;

            try
            {
                _service.SaveProvinceChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Debug.WriteLine($"Error updating province {provinceName} obvious feature description");
                return false;
            }
            return true;

        }

        public bool UpdateHiddenFeatureDescription(string provinceName, string featureText)
        {
            SelectedProvince = _service.GetProvinceByName(provinceName);
            if (SelectedProvince == null)
            {
                Debug.WriteLine($"Can't find province: {provinceName}");
                return false;
            }
            SelectedProvince.HiddenFeature = featureText;

            try
            {
                _service.SaveProvinceChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Debug.WriteLine($"Error updating province {provinceName} hidden feature description");
                return false;
            }
            return true;
        }

        public List<object> GetProvinceRandomEncounterDetails(string provinceName)
        {
            string? tableId;
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedProvince = _service.GetProvinceByName(provinceName);
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
            SelectedProvince = _service.GetProvinceByName(provinceName);
            SelectedProvince.RandEncounterTableId = tableId;
            _service.SaveProvinceChanges();
        }


    }
}
