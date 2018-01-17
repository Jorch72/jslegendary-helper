using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Edition
{
    public class EditionBLCUnitTests
    {
        private Mock<IEditionDAO> _mockDAO;
        private EditionBLC _blc;

        public EditionBLCUnitTests()
        {
            _mockDAO = new Mock<IEditionDAO>();
            _blc = new EditionBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetEditions_ReturnsEditions()
        {
            _mockDAO.Setup(m => m.GetEditions()).Returns(new List<Edition>());

            var result = _blc.GetEditions();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetEdition_ValidName_ReturnsEdition()
        {
            _mockDAO.Setup(m => m.GetEdition(It.IsAny<string>())).Returns(new Edition());

            var result = _blc.GetEdition("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void PostEdition_ExistingEdition_UpdatesEdition()
        {
            var edition = new Edition();
            _mockDAO.Setup(m => m.GetEdition(It.IsAny<string>())).Returns(edition);

            var result = _blc.PostEdition(edition);

            _mockDAO.Verify(m => m.UpdateEdition(edition));
        }

        [Fact]
        public void PostEdition_NewEdition_InsertsEdition()
        {
            _mockDAO.Setup(m => m.GetEdition(It.IsAny<string>())).Returns((Edition)null);
            var edition = new Edition();

            var result = _blc.PostEdition(edition);

            _mockDAO.Verify(m => m.InsertEdition(edition));
        }

        [Fact]
        public void PostEditions_ExistingEditions_UpdatesEditions()
        {
            var edition = new Edition();
            var editions = new List<Edition> { edition };
            _mockDAO.Setup(m => m.GetEdition(It.IsAny<string>())).Returns(edition);

            var result = _blc.PostEditions(editions);

            _mockDAO.Verify(m => m.UpdateEdition(edition));
        }

        [Fact]
        public void PostEditions_NewEditions_InsertEditions()
        {
            _mockDAO.Setup(m => m.GetEdition(It.IsAny<string>())).Returns((Edition)null);
            var edition = new Edition();
            var editions = new List<Edition> { edition };

            var result = _blc.PostEditions(editions);

            _mockDAO.Verify(m => m.InsertEdition(edition));
        }
    }
}