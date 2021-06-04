using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManagerData;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace DnDCampaignManagerApp
{
    public class RandomEncounterManager
    {
        public RandomEncounter SelectedEncounterTable { get; set; }
        private IRandomEncounterService _service;

        public RandomEncounterManager()
        {
            _service = new RandomEncounterService();
        }

        public RandomEncounterManager(IRandomEncounterService service)
        {
            _service = service ?? throw new ArgumentException("Random encounter service cannot be null");
        }

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
            _service.CreateTable(new RandomEncounter() { RandEncounterTableId = tableId, Dice = dice, RandEncounter = table });

        }

        // Update

        public bool UpdateTable(string tableId, string dice, string encounterTable)
        {
            CheckDiceFormat(dice);
            SelectedEncounterTable = _service.GetTableById(tableId);

            if (SelectedEncounterTable == null)
            {
                Debug.WriteLine($"Can't find random encounter table: {tableId}");
                return false;
            }

            SelectedEncounterTable.Dice = dice;
            SelectedEncounterTable.RandEncounter = encounterTable;

            try
            {
                _service.SaveRandEncounterChanges();
            }
            catch
            {
                Debug.WriteLine($"Error updating random encounter table: {tableId}");
                return false;
            }
            return true;
        }

        // Read
        // get the name, get the dice, get the table
        public List<object> GetTableDetails(string tableId)
        {
            List<object> tableDetails = new List<object>();

            SelectedEncounterTable = _service.GetTableById(tableId);

            tableDetails.Add(SelectedEncounterTable.RandEncounterTableId);
            tableDetails.Add(SelectedEncounterTable.Dice);
            tableDetails.Add(JObject.Parse(SelectedEncounterTable.RandEncounter));

            return tableDetails;
        }

        public List<RandomEncounter> GetListOfRandomEncounterTables()
        {
            return _service.GetRandomEncountersList();
        }

        // Delete
        public bool Delete(string tableId) 
        {

            SelectedEncounterTable = _service.GetTableById(tableId);
            if (SelectedEncounterTable == null)
            {
                Debug.WriteLine($"Can't find random encounter table: {tableId}");
                return false;
            }
            
            try
            {
                _service.RemoveTable(SelectedEncounterTable);
            }
            catch
            {
                Debug.WriteLine($"Error deleting random encounter table: {tableId}");
                return false;
            }
            SelectedEncounterTable = null;
            return true;

        }
    }
}
