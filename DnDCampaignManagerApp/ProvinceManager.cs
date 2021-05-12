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
        public List<string> GetProvinceDescriptions()
        {
            return new List<string>
            {
                "GetProvinceDescriptions not implemented",
                "GetProvinceDescriptions not implemented",
                "GetProvinceDescriptions not implemented"
            };
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
    }
}
