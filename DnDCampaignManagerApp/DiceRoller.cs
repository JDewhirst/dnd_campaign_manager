using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DnDCampaignManagerApp
{
    public static class DiceRoller
    {
        private static Random r = new Random();

        // Takes a string of the form "XdY" where X and Y are integers representing the number of dice and size of the dice respectively
        public static Tuple<int, int> ParseDice(string dice)
        {
            var split = dice.Split('d');
            int numDice = int.Parse(split[0]);
            int diceType = int.Parse(split[1]);
            return new Tuple<int, int>(numDice, diceType);
        }

        public static string RollDice(string dice)
        {
            var diceDetail = ParseDice(dice);
            var numDice = diceDetail.Item1;
            var dieSize = diceDetail.Item2;
            int result = 0;
            for (int i = 1; i <= numDice; i++)
            {
                result += r.Next(1, dieSize + 1);
            }
            return result.ToString();
        }

        public static string RollEncounter(List<object> randomEncounterDetails)
        {
            if ((string)randomEncounterDetails[1] != "No Table")
            {
                string diceResult = RollDice((string)randomEncounterDetails[1]);
                JObject table = (JObject)randomEncounterDetails[2];
                return (string)table[diceResult];
            }
            else
            {
                return "No random encounter table assigned to this province";
            }
        }
    }
}
