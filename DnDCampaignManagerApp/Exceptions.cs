using System;

namespace DnDCampaignManagerApp
{
    public class IncorrectDiceException : Exception
    {
        public override string Message
        {
            get
            {
                return "Dice must be in the format 'XdY', X and Y must be positive integers and not zero";
            }
        }
    }
}
