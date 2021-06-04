using System.Linq;
using CampaignManagerData;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace DnDCampaignManagerApp
{
    public class TerrainManager
    {
        public TerrainDetail SelectedTerrain { get; set; }
        private ITerrainService _service;

        public TerrainManager()
        {
            _service = new TerrainService();
        }

        public TerrainManager(ITerrainService service)
        {
            _service = service ?? throw new ArgumentException("Terrain service cannot be null");
        }

        public void SetSelectedTerrain(object selectedItem)
        {
            SelectedTerrain = (TerrainDetail)selectedItem;
        }

        public string GetTerrainDescription(string terrainId)
        {
            return _service.GetTerrainDescription(terrainId);
        }

        public string GetTerrainSpeed(string terrainId)
        {
            return _service.GetTerrainSpeed(terrainId).ToString();
            
        }

        public void CreateTerrain(string terrainId, string terrainDescription, int travelSpeed)
        {
            _service.CreateTerrain(terrainId, terrainDescription, travelSpeed);
        }
    }
}
