﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CampaignManagerData
{
    public partial class RandomEncounter
    {
        public RandomEncounter()
        {
            Provinces = new HashSet<Province>();
        }

        public string RandEncounterTableId { get; set; }
        public string RandEncounter { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
