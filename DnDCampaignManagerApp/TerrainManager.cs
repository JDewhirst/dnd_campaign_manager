using System.Linq;
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

        public void CreateTerrain(string terrainId, string terrainDescription, int travelSpeed)
        {
            TerrainDetail newTerrain = new TerrainDetail
            {
                TerrainId = terrainId,
                TerrainDescription = terrainDescription,
                TerrainTravelSpeed = travelSpeed
            };
            using (var db = new DnDCampaignManagerContext())
            {
                db.TerrainDetails.Add(newTerrain);
                db.SaveChanges();
            }
        }
    }
}
