using System;
using System.Collections.Generic;

#nullable disable

namespace CampaignManagerData
{
    public partial class TerrainDetail
    {
        public TerrainDetail()
        {
            Provinces = new HashSet<Province>();
        }

        public string TerrainId { get; set; }
        public string TerrainDescription { get; set; }
        public int TerrainTravelSpeed { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
