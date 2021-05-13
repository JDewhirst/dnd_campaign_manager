using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignManagerData;
using Newtonsoft.Json.Linq;

namespace DnDCampaignManagerApp
{
    public class RandomEncounterManager
    {
        public RandomEncounter SelectedEncounterTable { get; set; }

        // Create 

        // Update

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

        // Delete
    }
}
