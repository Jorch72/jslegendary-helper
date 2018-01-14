using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace VillainDeck
{
    public class SchemeBLCUnitTests
    {
        private SchemeBLC _blc;

        public SchemeBLCUnitTests()
        {
            var daoMock = new Mock<ISchemeDAO>();
            daoMock.Setup(d => d.GetSchemes())
                .ReturnsAsync(GetTestSchemes());

            _blc = new SchemeBLC(daoMock.Object);
        }

        [Fact]
        public async void GetFilteredSchemes_ReturnsFilteredSchemes()
        {
            var filter = new Filter 
            { 
                Editions = new List<string> { "Core" } 
            };

            var result = await _blc.GetFilteredSchemes(filter);

            Assert.True(result.All(s => filter.Editions.Contains(s.Edition)));
        }

        [Fact]
        public async void GetScheme_ReturnsScheme()
        {
            var filter = new Filter 
            { 
                Editions = new List<string> { "Core" } 
            };

            var result = await _blc.GetScheme(filter);

            Assert.True(filter.Editions.Contains(result.Edition));
        }

        public List<Scheme> GetTestSchemes()
        {
            var schemes = new List<Scheme>
            {
                new Scheme { Name = "test1", Edition = "Core" },
                new Scheme { Name = "test2", Edition = "Core" },
                new Scheme { Name = "test3", Edition = "Core" },
                new Scheme { Name = "test4", Edition = "Dark City" },
                new Scheme { Name = "test5", Edition = "Dark City" }
            };
            
            return schemes;
        }
    }
}