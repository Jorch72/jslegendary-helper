using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Mastermind
{
    public class MastermindBLCUnitTests
    {
        private Mock<IMastermindDAO> _mockDAO;
        private MastermindBLC _blc;

        public MastermindBLCUnitTests()
        {
            _mockDAO = new Mock<IMastermindDAO>();
            _blc = new MastermindBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetMasterminds_ReturnsMasterminds()
        {
            _mockDAO.Setup(m => m.GetMasterminds()).Returns(new List<Mastermind>());

            var result = _blc.GetMasterminds();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetMastermind_ValidName_ReturnsMastermind()
        {
            var mastermind = new Mastermind();
            _mockDAO.Setup(m => m.GetMastermind(It.IsAny<string>())).Returns(mastermind);

            var result = _blc.GetMastermind("test");

            Assert.Equal(mastermind, result);
        }

        [Fact]
        public void PostMastermind_ExistingMastermind_UpdatesMastermind()
        {
            var mastermind = new Mastermind();
            _mockDAO.Setup(m => m.GetMastermind(It.IsAny<string>())).Returns(mastermind);

            var result = _blc.PostMastermind(mastermind);

            _mockDAO.Verify(m => m.UpdateMastermind(mastermind));
        }

        [Fact]
        public void PostMastermind_NewMastermind_InsertsMastermind()
        {
            var mastermind = new Mastermind();
            _mockDAO.Setup(m => m.GetMastermind(It.IsAny<string>())).Returns((Mastermind)null);

            var result = _blc.PostMastermind(mastermind);

            _mockDAO.Verify(m => m.InsertMastermind(mastermind));
        }

        [Fact]
        public void PostMasterminds_ExistingMastermind_UpdatesMastermind()
        {
            var mastermind = new Mastermind();
            var masterminds = new List<Mastermind> { mastermind };
            _mockDAO.Setup(m => m.GetMastermind(It.IsAny<string>())).Returns(mastermind);

            var result = _blc.PostMasterminds(masterminds);

            _mockDAO.Verify(m => m.UpdateMastermind(mastermind));
        }

        [Fact]
        public void PostMasterminds_NewMastermind_InsertsMastermind()
        {
            var mastermind = new Mastermind();
            var masterminds = new List<Mastermind> { mastermind };
            _mockDAO.Setup(m => m.GetMastermind(It.IsAny<string>())).Returns((Mastermind)null);

            var result = _blc.PostMasterminds(masterminds);

            _mockDAO.Verify(m => m.InsertMastermind(mastermind));
        }
    }
}