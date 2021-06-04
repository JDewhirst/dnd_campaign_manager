using System;
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

        private void CheckDiceFormat(string dice)
        {
            var splitDice = dice.Split("d");
            if (splitDice.Count() != 2 || splitDice.Contains("0"))
            {
                throw new IncorrectDiceException();
            }

        }

        // Create 
        public void CreateTable(string tableId, string dice, string table)
        {

            CheckDiceFormat(dice);
            using (var db = new DnDCampaignManagerContext())
            {
                db.RandomEncounters.Add(new RandomEncounter() { RandEncounterTableId = tableId, Dice = dice, RandEncounter = table });
                db.SaveChanges();
            }
        }

        // Update

        public void UpdateTable(string tableId, string dice, string encounterTable)
        {
            CheckDiceFormat(dice);
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedTable = db.RandomEncounters.Where(re => re.RandEncounterTableId == tableId).FirstOrDefault();
                selectedTable.Dice = dice;
                selectedTable.RandEncounter = encounterTable;
                db.SaveChanges();
            }
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
                
                var provinces = db.Provinces.Where(p => p.RandEncounterTableId == tableId).ToList();
                provinces.ForEach(p => p.RandEncounterTableId = null);
                
                var tableToDelete = db.RandomEncounters.Where(re => re.RandEncounterTableId == tableId).FirstOrDefault();
                db.RandomEncounters.RemoveRange(tableToDelete);
                db.SaveChanges();
            }
        }
    }
}
