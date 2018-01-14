using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace VillainDeck
{
    public class MastermindBLCUnitTests
    {
        private MastermindBLC _blc;

        public MastermindBLCUnitTests()
        {
            var daoMock = new Mock<IMastermindDAO>();
            daoMock.Setup(d => d.GetMasterminds())
                .ReturnsAsync(GetTestMasterminds());

            _blc = new MastermindBLC(daoMock.Object);
        }

        [Fact]
        public void GetRandomMastermind_ReturnsMastermindFromFilteredList()
        {
            var masterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" },
                new Mastermind { Name = "test3" }
            };

            var filteredMasterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" },
                new Mastermind { Name = "test3" },
                new Mastermind { Name = "test4" },
                new Mastermind { Name = "test5" }
            };

            var result = _blc.GetRandomMastermind(masterminds, filteredMasterminds);

            Assert.True(!masterminds.Any(h => h.Name == result.Name));
        }

        [Fact]
        public void GetMastermindsFromRules_NoRules_ReturnsEmptyListOfMasterminds()
        {
            var filteredMasterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" },
                new Mastermind { Name = "test3" },
                new Mastermind { Name = "test4" },
                new Mastermind { Name = "test5" }
            };

            var result1 = _blc.GetMastermindsFromRules(null, filteredMasterminds);
            var result2 = _blc.GetMastermindsFromRules(new List<Rule>(), filteredMasterminds);

            Assert.True(result1.Count == 0);
            Assert.True(result2.Count == 0);
        }

        [Fact]
        public void GetMastermindsFromRules_NoMastermindsRules_ReturnsEmptyListOfMasterminds()
        {
            var filteredMasterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" },
                new Mastermind { Name = "test3" },
                new Mastermind { Name = "test4" },
                new Mastermind { Name = "test5" }
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Mastermind",
                    Type = "Mastermind",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Mastermind",
                    Type = "Mastermind",
                    Name = "test2"
                }
            };

            var result = _blc.GetMastermindsFromRules(rules, filteredMasterminds);

            Assert.True(result.Count == 0);
        }
        
        [Fact]
        public void GetMastermindsFromRules_MastermindsRules_ReturnsSpecificMasterminds()
        {
            var filteredMasterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" },
                new Mastermind { Name = "test3" },
                new Mastermind { Name = "test4" },
                new Mastermind { Name = "test5" }
            };

            var rules = new List<Rule> 
            {
                new Rule 
                {
                    Deck = "Mastermind",
                    Type = "MastermindRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Mastermind",
                    Type = "MastermindRule",
                    Name = "test2"
                }
            };

            var result = _blc.GetMastermindsFromRules(rules, filteredMasterminds);

            Assert.True(result.All(h => rules.Any(r => r.Name == h.Name)));
        }
        
        [Fact]
        public async void GetFilteredMasterminds_ReturnsFilteredMasterminds()
        {
            var henchmen = new List<Mastermind>
            {
                new Mastermind { Name = "test1", Edition = "Core" },
                new Mastermind { Name = "test2", Edition = "Core" },
                new Mastermind { Name = "test3", Edition = "Core" },
                new Mastermind { Name = "test4", Edition = "Dark City" },
                new Mastermind { Name = "test5", Edition = "Dark City" }
            };

            var filter = new Filter
            {
                Editions = new List<string> { "Dark City" }
            };

            var result = await _blc.GetFilteredMasterminds(filter);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
        }

        [Fact]
        public async void GetMasterminds_ReturnsMasterminds()
        {

            var filter = new Filter
            {
                Editions = new List<string> { "Core", "Dark City" },
                MaxMasterminds = 3
            };

            var rules = new List<Rule> 
            {
                new Rule 
                { 
                    Deck = "Mastermind",
                    Type = "MastermindRule",
                    Name = "test1"
                },
                new Rule 
                { 
                    Deck = "Mastermind",
                    Type = "MastermindRule",
                    Name = "test5"
                }
            };

            var result = await _blc.GetMasterminds(filter, rules);

            Assert.True(result.All(h => filter.Editions.Contains(h.Edition)));
            Assert.True(rules.All(r => result.Any(h => h.Name == r.Name)));
        }
        
        public List<Mastermind> GetTestMasterminds()
        {
            var masterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1", Edition = "Core" },
                new Mastermind { Name = "test2", Edition = "Core" },
                new Mastermind { Name = "test3", Edition = "Core" },
                new Mastermind { Name = "test4", Edition = "Core" },
                new Mastermind { Name = "test5", Edition = "Dark City" },
                new Mastermind { Name = "test6", Edition = "Dark City" },
                new Mastermind { Name = "test7", Edition = "Dark City" },
                new Mastermind { Name = "test8", Edition = "Civil War" },
                new Mastermind { Name = "test9", Edition = "Civil War" }
            };

            return masterminds;
        }
    }
}