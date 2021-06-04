using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using Moq;

namespace DnDCampaignManagerTests
{
    public class TerrainManagerShould
    {
        private TerrainManager _sut;

        [Test]
        public void BeAbleToConstruct_TerrainManager()
        {
            var mockTerrainService = new Mock<ITerrainService>(0);

            _sut = new TerrainManager(mockTerrainService.Object);

            Assert.That(_sut, Is.InstanceOf<TerrainManager>());
        }
       

    }
}