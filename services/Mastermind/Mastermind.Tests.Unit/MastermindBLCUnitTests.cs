using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Mastermind
{
    public class MastermindBLCUnitTests
    {
        private const string NEW = "new";
        private const string EXISTING = "existing";
        private MastermindBLC _blc;

        public MastermindBLCUnitTests()
        {
            var daoMock = new Mock<IMastermindDAO>();
            daoMock.Setup(d => d.GetMasterminds())
                .Returns(new List<Mastermind> 
                {
                    new Mastermind(),
                    new Mastermind()
                });

            daoMock.Setup(d => d.GetMastermind(It.IsAny<string>()))
                .Returns((string name) => 
                {
                    if(name == NEW)
                        return null;
                    else
                        return new Mastermind 
                            {  
                                Name = name,
                                Edition = "oldEdition"
                            };
                });

            daoMock.Setup(d => d.InsertMastermind(It.IsAny<Mastermind>()))
                .Returns((Mastermind Mastermind) => Mastermind);

            daoMock.Setup(d => d.UpdateMastermind(It.IsAny<Mastermind>()))
                .Returns((Mastermind Mastermind) => Mastermind);

            _blc = new MastermindBLC(daoMock.Object);
        }

        [Fact]
        public void GetMasterminds_ReturnsMasterminds()
        {
            var result = _blc.GetMasterminds();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void GetMastermind_ValidName_ReturnsMastermind()
        {
            var result = _blc.GetMastermind(EXISTING);

            Assert.Equal(EXISTING, result.Name);
        }

        [Fact]
        public void PostMastermind_ExistingMastermind_UpdatesMastermind()
        {
            var mastermind = new Mastermind
            {
                Name = EXISTING,
                Edition = "newEdition"
            };

            var result = _blc.PostMastermind(mastermind);

            Assert.Equal(mastermind.Edition, result.Edition);
        }

        [Fact]
        public void PostMastermind_NewMastermind_InsertsMastermind()
        {
            var mastermind = new Mastermind
            {
                Name = NEW
            };

            var result = _blc.PostMastermind(mastermind);

            Assert.Equal(mastermind.Name, result.Name);
        }

        [Fact]
        public void PostMasterminds_NewAndExistingMasterminds_InsertsAndUpdatesMasterminds()
        {
            var masterminds = new List<Mastermind>
            {
                new Mastermind { Name = NEW, Edition = "Core" },
                new Mastermind { Name = EXISTING, Edition = "Core" }
            };

            var result = _blc.PostMasterminds(masterminds);

            Assert.True(result.All(m => masterminds.Any(mm => mm.Name == m.Name)));
        }
    }
}