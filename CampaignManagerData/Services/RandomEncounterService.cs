using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public class RandomEncounterService : IRandomEncounterService
    {
        private readonly DnDCampaignManagerContext _context;
        public RandomEncounterService(DnDCampaignManagerContext context)
        {
            _context = context;
        }
        public RandomEncounterService()
        {
            _context = new DnDCampaignManagerContext();
        }

        public void CreateTable(RandomEncounter r)
        {
            _context.RandomEncounters.Add(r);
            _context.SaveChanges();
        }

        public void RemoveTable(RandomEncounter r)
        {
            _context.RandomEncounters.Remove(r);
            _context.SaveChanges();
        }

        public RandomEncounter GetTableById(string tableId)
        {
            return _context.RandomEncounters.Where(re => re.RandEncounterTableId == tableId).FirstOrDefault();
        }

        public void SaveRandEncounterChanges()
        {
            _context.SaveChanges();
        }

        public List<RandomEncounter> GetRandomEncountersList()
        {
            return _context.RandomEncounters.ToList();
        }
    }
}
