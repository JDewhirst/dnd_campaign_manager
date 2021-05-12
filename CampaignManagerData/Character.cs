using System;
using System.Collections.Generic;

#nullable disable

namespace CampaignManagerData
{
    public partial class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public bool? IsPlayerCharacter { get; set; }
        public string CharacterDescription { get; set; }
        public int Coordinates { get; set; }

        public virtual Province CoordinatesNavigation { get; set; }
    }
}
