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
            int numDice = Convert.ToInt32(dice.Split('d')[0]);
            int diceType = Convert.ToInt32(dice.Split('d')[1]);
            int result = 0;
            for (int i = 1; i <= numDice; i++)
            {
                result += r.Next(1, diceType);
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
