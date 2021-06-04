using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public class ProvinceService : IProvinceService
    {
        private readonly DnDCampaignManagerContext _context;
        public ProvinceService(DnDCampaignManagerContext context)
        {
            _context = context;
        }
        public ProvinceService()
        {
            _context = new DnDCampaignManagerContext();
        }

        public int GetNumberOfProvinces()
        {
            return _context.Provinces.Count();
        }

        public List<Province> GetAllProvincesQuery()
        {
            return _context.Provinces.ToList();
        }

        public Province GetProvinceByName(string provinceName)
        {
            return _context.Provinces.Where(p => p.ProvinceName == provinceName).FirstOrDefault();
        }

        public void SaveProvinceChanges()
        {
            _context.SaveChanges();
        }
    }
}
