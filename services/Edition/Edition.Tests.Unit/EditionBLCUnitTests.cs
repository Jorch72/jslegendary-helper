using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Edition
{
    public class EditionBLCUnitTests
    {
        private const string NEW = "new";
        private const string EXISTING = "existing";
        private EditionBLC _blc;

        public EditionBLCUnitTests()
        {
            var daoMock = new Mock<IEditionDAO>();
            daoMock.Setup(d => d.GetEditions())
                .Returns(new List<Edition>
                {
                    new Edition(),
                    new Edition()
                });

            daoMock.Setup(d => d.GetEdition(It.IsAny<string>()))
                .Returns((string editionName) => 
                {
                    if(editionName == NEW)
                        return null;
                    else
                        return new Edition 
                            {  
                                Id = 1,
                                Name = EXISTING
                            };
                });

            daoMock.Setup(d => d.InsertEdition(It.IsAny<Edition>()))
                .Returns((Edition edition) => edition);

            daoMock.Setup(d => d.UpdateEdition(It.IsAny<Edition>()))
                .Returns((Edition edition) => edition);

            _blc = new EditionBLC(daoMock.Object);
        }

        [Fact]
        public void GetEditions_ReturnsEditions()
        {
            var result = _blc.GetEditions();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void GetEdition_ValidName_ReturnsEdition()
        {
            var result = _blc.GetEdition(EXISTING);

            Assert.Equal(EXISTING, result.Name);
        }

        [Fact]
        public void PostEdition_ExistingEdition_UpdatesEdition()
        {
            var edition = new Edition
            {
                Id = 1,
                Name = EXISTING
            };

            var result = _blc.PostEdition(edition);

            Assert.Equal(edition.Name, result.Name);
        }

        [Fact]
        public void PostEdition_NewEdition_InsertsEdition()
        {
            var edition = new Edition
            {
                Id = 5,
                Name = NEW
            };

            var result = _blc.PostEdition(edition);

            Assert.Equal(edition.Name, result.Name);
        }

        [Fact]
        public void PostEditions_NewAndExistingEditions_InsertsAndUpdatesEditions()
        {
            var editions = new List<Edition>
            {
                new Edition { Id = 1, Name = EXISTING },
                new Edition { Id = 10, Name = NEW }
            };

            var result = _blc.PostEditions(editions);

            Assert.True(result.All(m => editions.Any(mm => mm.Name == m.Name)));
        }
    }
}