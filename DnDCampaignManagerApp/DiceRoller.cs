using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCampaignManagerApp
{
    public static class DiceRoller
    {
        static Random r = new Random();

        public static string RollDice(string dice)
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
    }
}
