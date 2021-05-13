using System;
using System.Collections.Generic;

#nullable disable

namespace CampaignManagerData
{
    public partial class Province
    {
        public Province()
        {
            Characters = new HashSet<Character>();
        }

        public int Coordinates { get; set; }
        public string ProvinceName { get; set; }
        public string TerrainId { get; set; }
        public string ObviousFeature { get; set; }
        public string HiddenFeature { get; set; }
        public string RandEncounterTableId { get; set; }

        public virtual RandomEncounter RandEncounterTable { get; set; }
        public virtual TerrainDetail Terrain { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

        public override string ToString()
        {
            return ProvinceName;
        }
    }
}
