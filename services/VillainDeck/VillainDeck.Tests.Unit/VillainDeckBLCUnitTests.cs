using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace VillainDeck
{
    public class VillainDeckBLCUnitTests
    {
        private VillainDeckBLC _blc;

        public VillainDeckBLCUnitTests()
        {
            var schemeBLC = GetTestSchemeBLC();
            var mastermindBLC = GetTestMastermindBLC();
            var villainBLC = GetTestVillainBLC();
            var henchmanBLC = GetTestHenchmanBLC();

            _blc = new VillainDeckBLC(schemeBLC,
                mastermindBLC,
                villainBLC,
                henchmanBLC);
        }

        [Fact]
        public void AddRules_NoRules_ReturnsUnmodifiedRules()
        {
            var rules = new List<Rule>();
            var card = new Card();

            var result = _blc.AddRules(rules, card);

            Assert.True(result.Count == 0);
        }

        [Fact]
        public void ApplySetupRules_NoRules_ReturnsUnmodifiedFilter()
        {
            
        }

        public ISchemeBLC GetTestSchemeBLC()
        {
            var blcMock = new Mock<ISchemeBLC>();
            blcMock.Setup(b => b.GetScheme(It.IsAny<Filter>()))
                .ReturnsAsync(
                    new Scheme 
                    { 
                        Name = "test", 
                        Edition = "Core", 
                        Rules = new List<Rule>
                        {
                            new Rule
                            {
                                Deck = "Villain",
                                Type = "VillainRule",
                                Name = "test1"
                            }
                        }
                    });
            
            return blcMock.Object;
        }

        public IMastermindBLC GetTestMastermindBLC()
        {
            var blcMock = new Mock<IMastermindBLC>();
            blcMock.Setup(b => b.GetMasterminds(It.IsAny<Filter>(), It.IsAny<List<Rule>>()))
                .ReturnsAsync(new List<Mastermind>
                {
                    new Mastermind
                    {
                        Name = "test",
                        Edition = "Core",
                        Rules = new List<Rule>
                        {
                            new Rule 
                            {
                                Deck = "Villain",
                                Type = "VillainRule",
                                Name = "test"
                            }
                        }
                    }
                });

            return blcMock.Object;
        }

        public IVillainBLC GetTestVillainBLC()
        {
            var blcMock = new Mock<IVillainBLC>();
            blcMock.Setup(b => b.GetVillains(It.IsAny<Filter>(), It.IsAny<List<Rule>>()))
                .ReturnsAsync(new List<Villain>
                {
                    new Villain { Name = "test1", Edition = "Core" },
                    new Villain { Name = "test2", Edition = "Core" },
                    new Villain { Name = "test3", Edition = "Core" },
                    new Villain { Name = "test4", Edition = "Core" },
                    new Villain { Name = "test5", Edition = "Core" }
                });

            return blcMock.Object;
        }

        public IHenchmanBLC GetTestHenchmanBLC()
        {
            var blcMock = new Mock<IHenchmanBLC>();
            blcMock.Setup(b => b.GetHenchmen(It.IsAny<Filter>(), It.IsAny<List<Rule>>()))
                .ReturnsAsync(new List<Henchman>
                {
                    new Henchman { Name = "test1", Edition = "Core" },
                    new Henchman { Name = "test2", Edition = "Core" },
                    new Henchman { Name = "test3", Edition = "Core" },
                    new Henchman { Name = "test4", Edition = "Core" },
                    new Henchman { Name = "test5", Edition = "Core" }
                });

            return blcMock.Object;
        }
    }
}