using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace VillainDeck
{
    public class HenchmanBLCUnitTests
    {
        private HenchmanBLC _blc;

        public HenchmanBLCUnitTests()
        {
            var daoMock = new Mock<IHenchmanDAO>();
            daoMock.Setup(d => d.GetHenchmen())
                .ReturnsAsync(GetTestHenchmen());

            _blc = new HenchmanBLC(daoMock.Object);
        }

        #region Tests

        [Fact]
        public void GetRandomHenchman_ReturnsHenchmanFromFilteredList()
        {
            var henchmen = new List<Henchman>
            {
                new Henchman { Name = "test1" },
                new Henchman { Name = "test2" },
                new Henchman { Name = "test3" }
            };

            var filteredHenchmen = new List<Henchman>
            {
                new Henchman { Name = "test1" },
                new Henchman { Name = "test2" },
                new Henchman { Name = "test3" },
                new Henchman { Name = "test4" },
                new Henchman { Name = "test5" }
            };

            var result = _blc.GetRandomHenchman(henchmen, filteredHenchmen);

            Assert.True(!henchmen.Any(h => h.Name == result.Name));
        }

        [Fact]
        public void GetHenchmenFromRules_NoRules_ReturnsEmptyListOfHenchmen()
        {
            var filteredHenchmen = new List<Henchman>
            {
                new Henchman { Name = "test1" },
                new Henchman { Name = "test2" },
                new Henchman { Name = "test3" },
                new Henchman { Name = "test4" },
                new Henchman { Name = "test5" }
            };

            var result1 = _blc.GetHenchmenFromRules(null, filteredHenchmen);
            var result2 = _blc.GetHenchmenFromRules(new List<Rule>(), filteredHenchmen);

            Assert.True(result1.Count == 0);
            Assert.True(result2.Count == 0);
        }

        [Fact]
        public void GetHenchmenFromRules_NoHenchmenRules_ReturnsEmptyListOfHenchmen()
        {
            var filteredHenchmen = new List<Henchman>
            {
                new Henchman { Name = "test1" },
                new Henchman { Name = "test2" },
                new Henchman { Name = "test3" },
                new Henchman { Name = "test4" },
                new Henchman { Name = "test5" }
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

            var result = _blc.GetHenchmenFromRules(rules, filteredHenchmen);

            Assert.True(result.Count == 0);
        }

        [Fact]
        public void GetHenchmenFromRules_HenchmenRules_ReturnsSpecificHenchmen()
        {
            var filteredHenchmen = new List<Henchman>
            {
                new Henchman { Name = "test1" },
                new Henchman { Name = "test2" },
                new Henchman { Name = "test3" },
                new Henchman { Name = "test4" },
                new Henchman { Name = "test5" }
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "HenchmanRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "HenchmanRule",
                    Name = "test2"
                }
            };

            var result = _blc.GetHenchmenFromRules(rules, filteredHenchmen);

            Assert.True(result.All(h => rules.Any(r => r.Name == h.Name)));
        }

        [Fact]
        public async void GetFilteredHenchmen_ReturnsFilteredHenchmen()
        {
            var henchmen = new List<Henchman>
            {
                new Henchman { Name = "test1", Edition = "Core" },
                new Henchman { Name = "test2", Edition = "Core" },
                new Henchman { Name = "test3", Edition = "Core" },
                new Henchman { Name = "test4", Edition = "Dark City" },
                new Henchman { Name = "test5", Edition = "Dark City" }
            };

            var filter = new Filter
            {
                Editions = new List<string> { "Dark City" }
            };

            var result = await _blc.GetFilteredHenchmen(filter);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
        }

        [Fact]
        public async void GetHenchmen_ReturnsHenchmen()
        {

            var filter = new Filter
            {
                Editions = new List<string> { "Core", "Dark City" },
                MaxHenchmen = 3
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "HenchmanRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Villain",
                    Type = "HenchmanRule",
                    Name = "test5"
                }
            };

            var result = await _blc.GetHenchmen(filter, rules);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
            Assert.True(rules.All(r => result.Any(h => h.Name == r.Name)));
        }

        #endregion

        #region Setup Data

        public List<Henchman> GetTestHenchmen()
        {
            var henchmen = new List<Henchman>
            {
                new Henchman { Name = "test1", Edition = "Core" },
                new Henchman { Name = "test2", Edition = "Core" },
                new Henchman { Name = "test3", Edition = "Core" },
                new Henchman { Name = "test4", Edition = "Dark City" },
                new Henchman { Name = "test5", Edition = "Dark City" },
                new Henchman { Name = "test6", Edition = "Paint the Town Red" },
                new Henchman { Name = "test7", Edition = "Paint the Town Red" },
                new Henchman { Name = "test8", Edition = "Civil War" },
                new Henchman { Name = "test9", Edition = "Civil War" },
                new Henchman { Name = "test10", Edition = "Civil War" }
            };

            return henchmen;
        }

        #endregion
    }
}