using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Scheme
{
    public class SchemeBLCUnitTests
    {
        private const string NEW = "new";
        private const string EXISTING = "existing";
        private SchemeBLC _blc;

        public SchemeBLCUnitTests()
        {
            var daoMock = new Mock<ISchemeDAO>();
            daoMock.Setup(d => d.GetSchemes())
                .Returns(new List<Scheme>
                {
                    new Scheme(),
                    new Scheme()
                });

            daoMock.Setup(d => d.GetScheme(It.IsAny<string>()))
                .Returns((string name) => 
                {
                    if(name == NEW)
                        return null;
                    else
                        return new Scheme 
                            {  
                                Name = name,
                                Edition = "oldEdition"
                            };
                });

            daoMock.Setup(d => d.InsertScheme(It.IsAny<Scheme>()))
                .Returns((Scheme Scheme) => Scheme);

            daoMock.Setup(d => d.UpdateScheme(It.IsAny<Scheme>()))
                .Returns((Scheme Scheme) => Scheme);

            _blc = new SchemeBLC(daoMock.Object);
        }

        [Fact]
        public void GetSchemes_ReturnsSchemes()
        {
            var result = _blc.GetSchemes();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void GetScheme_ValidName_ReturnsScheme()
        {
            var result = _blc.GetScheme(EXISTING);

            Assert.Equal(EXISTING, result.Name);
        }

        [Fact]
        public void PostScheme_ExistingScheme_UpdatesScheme()
        {
            var Scheme = new Scheme
            {
                Name = EXISTING,
                Edition = "newEdition"
            };

            var result = _blc.PostScheme(Scheme);

            Assert.Equal(Scheme.Edition, result.Edition);
        }

        [Fact]
        public void PostScheme_NewScheme_InsertsScheme()
        {
            var Scheme = new Scheme
            {
                Name = NEW
            };

            var result = _blc.PostScheme(Scheme);

            Assert.Equal(Scheme.Name, result.Name);
        }

        [Fact]
        public void PostSchemes_NewAndExistingSchemes_InsertsAndUpdatesSchemes()
        {
            var Schemes = new List<Scheme>
            {
                new Scheme { Name = NEW, Edition = "Core" },
                new Scheme { Name = EXISTING, Edition = "Core" }
            };

            var result = _blc.PostSchemes(Schemes);

            Assert.True(result.All(m => Schemes.Any(mm => mm.Name == m.Name)));
        }
    }
}