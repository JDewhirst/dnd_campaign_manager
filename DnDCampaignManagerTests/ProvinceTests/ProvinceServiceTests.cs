using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DnDCampaignManagerTests
{
    public class ProvinceServiceTests
    {
        private ProvinceService _sut;
        private DnDCampaignManagerContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DnDCampaignManagerContext>().UseInMemoryDatabase(databaseName: "Example_DB").Options;
            _context = new DnDCampaignManagerContext(options);
            _sut = new ProvinceService(_context);

            // Add things to in memory database, if necessary
            _sut.CreateProvince(new Province() { Coordinates = 0, ProvinceName = "Wyrmsley" });
            _sut.CreateProvince(new Province() { Coordinates = 1, ProvinceName = "Hellington" });
        }

        [Test]
        public void GivenANewProvince_CreateProvinceAddsThemToTheDatabase()
        {
            var numOfCustomersPrior = _context.Provinces.Count();
            var newProvince = new Province { Coordinates = 3, ProvinceName = "Boston" };
            _sut.CreateProvince(newProvince);
            var numOfCustomersPost = _context.Provinces.Count();
            Assert.That(numOfCustomersPost, Is.EqualTo(numOfCustomersPost));
            var result = _sut.GetProvinceByName("Boston");
            Assert.That(result.Coordinates, Is.EqualTo(3));
            Assert.That(result.ProvinceName, Is.EqualTo("Boston"));

            _context.Provinces.Remove(newProvince);
            _context.SaveChanges();
        }

        [Test]
        public void GivenAValidProvinceName_GetProvinceByName_ReturnsCorrectProvince()
        {
            var result = _sut.GetProvinceByName("Wyrmsley");
            Assert.That(result, Is.TypeOf<Province>());
            Assert.That(result.ProvinceName, Is.EqualTo("Wyrmsley"));
            Assert.That(result.Coordinates, Is.EqualTo(0));
        }

        [Test]
        public void GivenWrongProvinceName_GetProvinceByName_ReturnsNull()
        {
            Assert.That(_sut.GetProvinceByName("Luna"), Is.Null);
        }


    }
}