using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace DnDCampaignManagerTests
{
    public class ProvinceManagerShould
    {
        private ProvinceManager _sut;

        [Test]
        public void BeAbleToConstruct_ProvinceManager()
        {
            var mockProvinceService = new Mock<IProvinceService>();

            _sut = new ProvinceManager(mockProvinceService.Object);

            Assert.That(_sut, Is.InstanceOf<ProvinceManager>());
        }

        [Test]
        public void ReturnTrue_WhenUpdateObviousFeatureDescriptionIscalled_WithValidProvinceName()
        {
            var mockProvinceService = new Mock<IProvinceService>();
            var originalProvince = new Province
            {
                Coordinates = 0,
                ProvinceName = "Wimbledon"

            };

            mockProvinceService.Setup(ps => ps.GetProvinceByName("Wimbledon")).Returns(originalProvince);

            _sut = new ProvinceManager(mockProvinceService.Object);
            var result = _sut.UpdateObviousFeatureDescription("Wimbledon", It.IsAny<string>());

            Assert.That(result);
        }

        [Test]
        public void ReturnFalse_WhenUpdateObviousFeatureDescriptionIsCallled_withInvalidProvinceName()
        {
            var mockProvinceService = new Mock<IProvinceService>();

            mockProvinceService.Setup(ps => ps.GetProvinceByName("Wimbledon")).Returns((Province)null);

            _sut = new ProvinceManager(mockProvinceService.Object);
            var result = _sut.UpdateObviousFeatureDescription("Wimbledon", It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnTrue_WhenUpdateHiddenFeatureDescriptionIscalled_WithValidProvinceName()
        {
            var mockProvinceService = new Mock<IProvinceService>();
            var originalProvince = new Province
            {
                Coordinates = 0,
                ProvinceName = "Wimbledon"

            };

            mockProvinceService.Setup(ps => ps.GetProvinceByName("Wimbledon")).Returns(originalProvince);

            _sut = new ProvinceManager(mockProvinceService.Object);
            var result = _sut.UpdateHiddenFeatureDescription("Wimbledon", It.IsAny<string>());

            Assert.That(result);
        }

        [Test]
        public void ReturnFalse_WhenUpdateHiddenFeatureDescriptionIsCallled_withInvalidProvinceName()
        {
            var mockProvinceService = new Mock<IProvinceService>();

            mockProvinceService.Setup(ps => ps.GetProvinceByName("Wimbledon")).Returns((Province)null);

            _sut = new ProvinceManager(mockProvinceService.Object);
            var result = _sut.UpdateHiddenFeatureDescription("Wimbledon", It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        [Test]
        public void CallSaveProvinceChanges_WhenUpdateObviousFeatureIsCalled_WithValidId()
        {
            // Arrange
            var mockProvinceService = new Mock<IProvinceService>();
            mockProvinceService.Setup(cs => cs.GetProvinceByName(It.IsAny<string>())).Returns(new Province());
            _sut = new ProvinceManager(mockProvinceService.Object);

            // Act
            _sut.UpdateObviousFeatureDescription("Wimbledon", It.IsAny<string>());
            mockProvinceService.Verify(cs => cs.SaveProvinceChanges(), Times.Once);
        }

        [Test]
        public void CallSaveProvinceChanges_WhenUpdateHiddenFeatureIsCalled_WithValidId()
        {
            // Arrange
            var mockProvinceService = new Mock<IProvinceService>();
            mockProvinceService.Setup(cs => cs.GetProvinceByName(It.IsAny<string>())).Returns(new Province());
            _sut = new ProvinceManager(mockProvinceService.Object);

            // Act
            _sut.UpdateHiddenFeatureDescription("Wimbledon", It.IsAny<string>());
            mockProvinceService.Verify(cs => cs.SaveProvinceChanges(), Times.Once);
        }


    }
}