using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Scheme
{
    public class SchemeBLCUnitTests
    {
        private Mock<ISchemeDAO> _mockDAO;
        private SchemeBLC _blc;

        public SchemeBLCUnitTests()
        {
            _mockDAO = new Mock<ISchemeDAO>();
            _blc = new SchemeBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetSchemes_ReturnsSchemes()
        {
            _mockDAO.Setup(m => m.GetSchemes()).Returns(new List<Scheme>());

            var result = _blc.GetSchemes();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetScheme_ValidName_ReturnsScheme()
        {
            var scheme = new Scheme();
            _mockDAO.Setup(m => m.GetScheme(It.IsAny<string>())).Returns(scheme);

            var result = _blc.GetScheme("test");

            Assert.Equal(scheme, result);
        }

        [Fact]
        public void PostScheme_ExistingScheme_UpdatesScheme()
        {
            var scheme = new Scheme();
            _mockDAO.Setup(m => m.GetScheme(It.IsAny<string>())).Returns(scheme);

            var result = _blc.PostScheme(scheme);

            _mockDAO.Verify(m => m.UpdateScheme(scheme));
        }

        [Fact]
        public void PostScheme_NewScheme_InsertsScheme()
        {
            var scheme = new Scheme();
            _mockDAO.Setup(m => m.GetScheme(It.IsAny<string>())).Returns((Scheme)null);

            var result = _blc.PostScheme(scheme);

            _mockDAO.Verify(m => m.InsertScheme(scheme));
        }

        [Fact]
        public void PostSchemes_ExistingScheme_UpdatesScheme()
        {
            var scheme = new Scheme();
            var schemes = new List<Scheme> { scheme };
            _mockDAO.Setup(m => m.GetScheme(It.IsAny<string>())).Returns(scheme);

            var result = _blc.PostSchemes(schemes);

            _mockDAO.Verify(m => m.UpdateScheme(scheme));
        }

        [Fact]
        public void PostSchemes_NewScheme_InsertsScheme()
        {
            var scheme = new Scheme();
            var schemes = new List<Scheme> { scheme };
            _mockDAO.Setup(m => m.GetScheme(It.IsAny<string>())).Returns((Scheme)null);

            var result = _blc.PostSchemes(schemes);

            _mockDAO.Verify(m => m.InsertScheme(scheme));
        }
    }
}