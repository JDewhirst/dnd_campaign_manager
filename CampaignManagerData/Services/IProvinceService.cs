using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public interface IProvinceService
    {
        public int GetNumberOfProvinces();
        public List<Province> GetAllProvincesQuery();
        public string GetProvinceHiddenFeature(string provinceName);
        public string GetProvinceObviousFeature(string provinceName);
        public string GetProvinceTravelSpeed(string provinceName);
        public void UpdateObviousFeatureDescription(string provinceName, string featureText);
        public void UpdateHiddenFeatureDescription(string provinceName, string featureText);
        public List<Object> GetProvinceRandomEncounterDetails(string provinceName);
        public void SetRandomEncounterTable(string provinceName, string tableId);
    }
}
