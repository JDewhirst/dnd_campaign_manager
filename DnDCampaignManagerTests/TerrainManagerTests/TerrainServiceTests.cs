using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DnDCampaignManagerTests
{
    public class TerrainServiceTests
    {
        private TerrainService _sut;
        private DnDCampaignManagerContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DnDCampaignManagerContext>().UseInMemoryDatabase(databaseName: "Example DB").Options;
            _context = new DnDCampaignManagerContext(options);
            _sut = new TerrainService(_context);

            _sut.CreateTerrain(new TerrainDetail { TerrainId = "Plain", TerrainDescription = "Very very flat", TerrainTravelSpeed = 1 });
            _sut.CreateTerrain(new TerrainDetail { TerrainId = "Hill", TerrainDescription = "Not flat at all", TerrainTravelSpeed = 2 });
        }

        [Test]
        public void GivenANewTerrain_CreateTerrainAddsItToTheDatabase()
        {
            var numOfTerrainsPrior = _context.TerrainDetails.Count();
            var newTerrain = new TerrainDetail { TerrainId = "Mountain", TerrainDescription = "Peaky", TerrainTravelSpeed=3};
            _sut.CreateTerrain(newTerrain);
            var numofTerrainsPost = _context.TerrainDetails.Count();
            Assert.That(numOfTerrainsPrior, Is.EqualTo(numofTerrainsPost - 1));
            Assert.That(_sut.GetTerrainDescription("Mountain"), Is.EqualTo("Peaky"));
            Assert.That(_sut.GetTerrainSpeed("Mountain"), Is.EqualTo(3));

            _context.TerrainDetails.Remove(newTerrain);
            _context.SaveChanges();
        }

        [TestCase("Plain", 1)]
        [TestCase("Hill", 2)]
        public void GivenValidTerrainId_GetTerrainSpeed_ReturnsCorrectSpeed(string input, int expected)
        {
            Assert.That(_sut.GetTerrainSpeed(input), Is.EqualTo(expected));
        }


        [TestCase("Plain", "Very very flat")]
        [TestCase("Hill", "Not flat at all")]
        public void GivenValidTerrainId_GetTerrainDescription_ReturnsCorrectDescription(string input, string expected)
        {
            Assert.That(_sut.GetTerrainDescription(input), Is.EqualTo(expected));
        }
    }
}