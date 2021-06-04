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

        public Province GetProvinceByName(string provinceName);
        public void SaveProvinceChanges();

        public void CreateProvince(Province p);
    }
}
