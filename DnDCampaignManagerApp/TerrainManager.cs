using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignManagerData;

namespace DnDCampaignManagerApp
{
    public class TerrainManager
    {
        public TerrainDetail SelectedTerrain { get; set; }

        public void SetSelectedTerrain(object selectedItem)
        {
            SelectedTerrain = (TerrainDetail)selectedItem;
        }

        public string GetTerrainDescription(string terrainId)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedTerrain = db.TerrainDetails.Where(td => td.TerrainId == terrainId).FirstOrDefault();
                return SelectedTerrain.TerrainDescription;
            }
        }

        public string GetTerrainSpeed(string terrainId)
        {
            using (var db = new DnDCampaignManagerContext())
            {
                SelectedTerrain = db.TerrainDetails.Where(td => td.TerrainId == terrainId).FirstOrDefault();
                return SelectedTerrain.TerrainTravelSpeed.ToString();
            }
        }
    }
}
