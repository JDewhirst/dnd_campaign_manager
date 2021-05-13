using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCampaignManagerApp
{
    public static class DiceRoller
    {
        private static Random r = new Random();

        private static string RollDice(string dice)
        {
            var diceDetail = ParseDice(dice);
            var numDice = diceDetail.Item1;
            var dieSize = diceDetail.Item2;
            int result = 0;
            for (int i = 1; i <= numDice; i++)
            {
                result += r.Next(1, dieSize);
            }
            return result.ToString();
        }

        private static Tuple<int, int> ParseDice(string dice)
        {
            int numDice = Convert.ToInt32(dice.Split('d')[0]);
            int diceType = Convert.ToInt32(dice.Split('d')[1]);
            Tuple<int, int> result = new Tuple<int, int>(numDice, diceType);
            return result;
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
