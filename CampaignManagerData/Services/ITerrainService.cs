using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public interface ITerrainService
    {
        public string GetTerrainDescription(string terrainId);

        public int GetTerrainSpeed(string terrainId);

        public void CreateTerrain(string terrainId, string terrainDescription, int travelSpeed);
    }
}
