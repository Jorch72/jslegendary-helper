using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace VillainDeck
{
    public class VillainBLCUnitTests
    {
        private VillainBLC _blc;

        public VillainBLCUnitTests()
        {
            var daoMock = new Mock<IVillainDAO>();
            daoMock.Setup(d => d.GetVillains())
                .ReturnsAsync(GetTestVillains());

            _blc = new VillainBLC(daoMock.Object);
        }

        [Fact]
        public void GetRandomVillain_ReturnsVillainFromFilteredList()
        {
            var villains = new List<Villain>
            {
                new Villain { Name = "test1" },
                new Villain { Name = "test2" },
                new Villain { Name = "test3" }
            };

            var filteredVillains = new List<Villain>
            {
                new Villain { Name = "test1" },
                new Villain { Name = "test2" },
                new Villain { Name = "test3" },
                new Villain { Name = "test4" },
                new Villain { Name = "test5" }
            };

            var result = _blc.GetRandomVillain(villains, filteredVillains);

            Assert.True(!villains.Any(h => h.Name == result.Name));
        }

        [Fact]
        public void GetVillainsFromRules_NoRules_ReturnsEmptyListOfVillains()
        {
            var filteredVillains = new List<Villain>
            {
                new Villain { Name = "test1" },
                new Villain { Name = "test2" },
                new Villain { Name = "test3" },
                new Villain { Name = "test4" },
                new Villain { Name = "test5" }
            };

            var result1 = _blc.GetVillainsFromRules(null, filteredVillains);
            var result2 = _blc.GetVillainsFromRules(new List<Rule>(), filteredVillains);

            Assert.True(result1.Count == 0);
            Assert.True(result2.Count == 0);
        }

        [Fact]
        public void GetVillainsFromRules_NoVillainsRules_ReturnsEmptyListOfVillains()
        {
            var filteredVillains = new List<Villain>
            {
                new Villain { Name = "test1" },
                new Villain { Name = "test2" },
                new Villain { Name = "test3" },
                new Villain { Name = "test4" },
                new Villain { Name = "test5" }
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "Villain",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "Villain",
                    Name = "test2"
                }
            };

            var result = _blc.GetVillainsFromRules(rules, filteredVillains);

            Assert.True(result.Count == 0);
        }
        
        [Fact]
        public void GetVillainsFromRules_VillainsRules_ReturnsSpecificVillains()
        {
            var filteredVillains = new List<Villain>
            {
                new Villain { Name = "test1" },
                new Villain { Name = "test2" },
                new Villain { Name = "test3" },
                new Villain { Name = "test4" },
                new Villain { Name = "test5" }
            };

            var rules = new List<Rule> 
            {
                new Rule 
                {
                    Deck = "Villain",
                    Type = "VillainRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "VillainRule",
                    Name = "test2"
                }
            };

            var result = _blc.GetVillainsFromRules(rules, filteredVillains);

            Assert.True(result.All(h => rules.Any(r => r.Name == h.Name)));
        }
        
        [Fact]
        public async void GetFilteredVillains_ReturnsFilteredVillains()
        {
            var henchmen = new List<Villain>
            {
                new Villain { Name = "test1", Edition = "Core" },
                new Villain { Name = "test2", Edition = "Core" },
                new Villain { Name = "test3", Edition = "Core" },
                new Villain { Name = "test4", Edition = "Dark City" },
                new Villain { Name = "test5", Edition = "Dark City" }
            };

            var filter = new Filter
            {
                Editions = new List<string> { "Dark City" }
            };

            var result = await _blc.GetFilteredVillains(filter);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
        }

        [Fact]
        public async void GetVillains_ReturnsVillains()
        {

            var filter = new Filter
            {
                Editions = new List<string> { "Core", "Dark City" },
                MaxVillains = 3
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "VillainRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "VillainRule",
                    Name = "test5"
                }
            };

            var result = await _blc.GetVillains(filter, rules);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
            Assert.True(rules.All(r => result.Any(h => h.Name == r.Name)));
        }
        
        public List<Villain> GetTestVillains()
        {
            var villains = new List<Villain>
            {
                new Villain { Name = "test1", Edition = "Core" },
                new Villain { Name = "test2", Edition = "Core" },
                new Villain { Name = "test3", Edition = "Core" },
                new Villain { Name = "test4", Edition = "Core" },
                new Villain { Name = "test5", Edition = "Dark City" },
                new Villain { Name = "test6", Edition = "Dark City" },
                new Villain { Name = "test7", Edition = "Dark City" },
                new Villain { Name = "test8", Edition = "Civil War" },
                new Villain { Name = "test9", Edition = "Civil War" }
            };

            return villains;
        }
    }
}