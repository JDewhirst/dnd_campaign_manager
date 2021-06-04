using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagerData
{
    public class TerrainService : ITerrainService
    {
        private readonly DnDCampaignManagerContext _context;
        public TerrainService(DnDCampaignManagerContext context)
        {
            _context = context;
        }
        public TerrainService()
        {
            _context = new DnDCampaignManagerContext();
        }

        public string GetTerrainDescription(string terrainId)
        {
            return _context.TerrainDetails.Where(td => td.TerrainId == terrainId).FirstOrDefault().TerrainDescription;
        }

        public int GetTerrainSpeed(string terrainId)
        {
            return _context.TerrainDetails.Where(td => td.TerrainId == terrainId).FirstOrDefault().TerrainTravelSpeed;
        }

        public void CreateTerrain(TerrainDetail newTerrain)
        {
            _context.TerrainDetails.Add(newTerrain);
            _context.SaveChanges();
        }
    }
}
