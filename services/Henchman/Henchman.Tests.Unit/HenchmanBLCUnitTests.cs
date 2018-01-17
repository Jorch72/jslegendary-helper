using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Henchman
{
    public class HenchmanBLCUnitTests
    {
        private Mock<IHenchmanDAO> _mockDAO;
        private HenchmanBLC _blc;

        public HenchmanBLCUnitTests()
        {
            _mockDAO = new Mock<IHenchmanDAO>();
            _blc = new HenchmanBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetHenchmen_ReturnsHenchmen()
        {
            _mockDAO.Setup(m => m.GetHenchmen()).Returns(new List<Henchman>());

            var result = _blc.GetHenchmen();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetHenchman_ValidName_ReturnsHenchman()
        {
            _mockDAO.Setup(m => m.GetHenchman(It.IsAny<string>())).Returns(new Henchman());

            var result = _blc.GetHenchman("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void PostHenchman_ExistingHenchman_UpdatesHenchman()
        {
            var henchman = new Henchman();
            _mockDAO.Setup(m => m.GetHenchman(It.IsAny<string>())).Returns(henchman);

            var result = _blc.PostHenchman(henchman);

            _mockDAO.Verify(m => m.UpdateHenchman(henchman));
        }

        [Fact]
        public void PostHenchman_NewHenchman_InsertsHenchman()
        {
            var henchman = new Henchman();
            _mockDAO.Setup(m => m.GetHenchman(It.IsAny<string>())).Returns((Henchman)null);

            var result = _blc.PostHenchman(henchman);

            _mockDAO.Verify(m => m.InsertHenchman(henchman));
        }

        [Fact]
        public void PostHenchmen_ExistingHenchman_UpdatesHenchman()
        {
            var henchman = new Henchman();
            var henchmen = new List<Henchman> { henchman };
            _mockDAO.Setup(m => m.GetHenchman(It.IsAny<string>())).Returns(henchman);

            var result = _blc.PostHenchmen(henchmen);

            _mockDAO.Verify(m => m.UpdateHenchman(henchman));
        }

        [Fact]
        public void PostHenchmen_NewHenchman_InsertsHenchman()
        {
            var henchman = new Henchman();
            var henchmen = new List<Henchman> { henchman };
            _mockDAO.Setup(m => m.GetHenchman(It.IsAny<string>())).Returns((Henchman)null);

            var result = _blc.PostHenchmen(henchmen);

            _mockDAO.Verify(m => m.InsertHenchman(henchman));
        }
    }
}