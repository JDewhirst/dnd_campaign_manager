using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public interface IRandomEncounterService
    {
        private void CheckDiceFormat(string dice) { }
        public void CreateTable(RandomEncounter r);
        public void RemoveTable(RandomEncounter r);

        public RandomEncounter GetTableById(string tableId);

        public void SaveRandEncounterChanges();

        public List<RandomEncounter> GetRandomEncountersList();
    }
}
