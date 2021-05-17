using System.Collections.Generic;
using System.Linq;
using CampaignManagerData;
using Newtonsoft.Json.Linq;

namespace DnDCampaignManagerApp
{
    public class RandomEncounterManager
    {
        public RandomEncounter SelectedEncounterTable { get; set; }

        public void SetSelectedEnounterTable(object selectedItem)
        {
            SelectedEncounterTable = (RandomEncounter)selectedItem;
        }

        // Create 
        public void CreateTable(string tableId, string dice, string table)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                db.RandomEncounters.Add(new RandomEncounter() { RandEncounterTableId = tableId, Dice = dice, RandEncounter = table });
                db.SaveChanges();
            }
        }

        // Update
        public void UpdateTable(string tableId, string newTableId, string dice, string table)
        {
            Delete(tableId);
            CreateTable(newTableId, dice, table);
        }

        // Read
        // get the name, get the dice, get the table
        public List<object> GetTableDetails(string tableId)
        {
            List<object> tableDetails = new List<object>();
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedEncounterTable = db.RandomEncounters.Where(re => re.RandEncounterTableId == tableId).FirstOrDefault();
                tableDetails.Add(SelectedEncounterTable.RandEncounterTableId);
                tableDetails.Add(SelectedEncounterTable.Dice);
                tableDetails.Add(JObject.Parse(SelectedEncounterTable.RandEncounter));

            }
            return tableDetails;
        }

        public List<RandomEncounter> GetListOfRandomEncounterTables()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                return db.RandomEncounters.ToList();
            }    
        }

        // Delete
        public void Delete(string tableId) 
        {
            using (var db = new DnDCampaignManagerContext())
            {
                // delete references to this row in the provinces table
                var provinces = db.Provinces.Where(p => p.RandEncounterTableId == tableId).ToList();
                provinces.ForEach(p => p.RandEncounterTableId = null);
                
                // delete table
                var tableToDelete = db.RandomEncounters.Where(re => re.RandEncounterTableId == tableId).FirstOrDefault();
                db.RandomEncounters.RemoveRange(tableToDelete);
                db.SaveChanges();
            }
        }
    }
}
