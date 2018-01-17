using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Villain
{
    public class VillainBLCUnitTests
    {
        private Mock<IVillainDAO> _mockDAO;
        private VillainBLC _blc;

        public VillainBLCUnitTests()
        {
            _mockDAO = new Mock<IVillainDAO>();
            _blc = new VillainBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetVillains_ReturnsVillains()
        {
            _mockDAO.Setup(m => m.GetVillains()).Returns(new List<Villain>());

            var result = _blc.GetVillains();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetVillain_ValidName_ReturnsVillain()
        {
            var villain = new Villain();
            _mockDAO.Setup(m => m.GetVillain(It.IsAny<string>())).Returns(villain);

            var result = _blc.GetVillain("test");

            Assert.Equal(villain, result);
        }

        [Fact]
        public void PostVillain_ExistingVillain_UpdatesVillain()
        {
            var villain = new Villain();
            _mockDAO.Setup(m => m.GetVillain(It.IsAny<string>())).Returns(villain);

            var result = _blc.PostVillain(villain);

            _mockDAO.Verify(m => m.UpdateVillain(villain));
        }

        [Fact]
        public void PostVillain_NewVillain_InsertsVillain()
        {
            var villain = new Villain();
            _mockDAO.Setup(m => m.GetVillain(It.IsAny<string>())).Returns((Villain)null);

            var result = _blc.PostVillain(villain);

            _mockDAO.Verify(m => m.InsertVillain(villain));
        }

        [Fact]
        public void PostVillains_NewVillain_InsertsVillain()
        {
            var villain = new Villain();
            var villains = new List<Villain> { villain };
            _mockDAO.Setup(m => m.GetVillain(It.IsAny<string>())).Returns((Villain)null);

            var result = _blc.PostVillains(villains);

            _mockDAO.Verify(m => m.InsertVillain(villain));
        }

        [Fact]
        public void PostVillains_ExistingVillain_UpdatesVillain()
        {
            var villain = new Villain();
            var villains = new List<Villain> { villain };
            _mockDAO.Setup(m => m.GetVillain(It.IsAny<string>())).Returns(villain);

            var result = _blc.PostVillains(villains);

            _mockDAO.Verify(m => m.UpdateVillain(villain));
        }
    }
}