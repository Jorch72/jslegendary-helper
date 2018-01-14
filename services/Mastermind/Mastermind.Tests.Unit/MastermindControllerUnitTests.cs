using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Net.Http;

namespace Mastermind
{
    public class MastermindControllerUnitTests
    {
        private MastermindController _ctrl;

        public MastermindControllerUnitTests()
        {
            var blcMock = new Mock<IMastermindBLC>();
            blcMock.Setup(b => b.GetMasterminds())
                .Returns(new List<Mastermind>
                {
                    new Mastermind(),
                    new Mastermind()
                });

            blcMock.Setup(b => b.GetMastermind(It.IsAny<string>()))
                .Returns((string name) => new Mastermind { Name = name });

            blcMock.Setup(b => b.PostMastermind(It.IsAny<Mastermind>()))
                .Returns((Mastermind mastermind) => mastermind);

            blcMock.Setup(b => b.PostMasterminds(It.IsAny<List<Mastermind>>()))
                .Returns((List<Mastermind> masterminds) => masterminds);

            _ctrl = new MastermindController(blcMock.Object);
        }

        [Fact]
        public void Get_ReturnsMasterminds()
        {
            var result = _ctrl.Get();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void Get_ValidName_ReturnsMastermind()
        {
            var name = "test";

            var result = _ctrl.Get(name);

            Assert.Equal(name, result.Name);
        }

        [Fact]
        public void Get_Null_ThrowsException()
        {
            Assert.Throws<HttpRequestException>(() => _ctrl.Get(null));
        }

        [Fact]
        public void Post_SingleMastermind_ReturnsMastermind()
        {
            var mastermind = new Mastermind { Name = "test" };

            var result = _ctrl.Post(mastermind);

            Assert.Equal(mastermind.Name, result.Name);
        }

        [Fact]
        public void Post_MultipleMasterminds_ReturnsMasterminds()
        {
            var masterminds = new List<Mastermind>
            {
                new Mastermind { Name = "test1" },
                new Mastermind { Name = "test2" }
            };

            var result = _ctrl.Post(masterminds);

            Assert.True(result.All(m => masterminds.Any(mm => mm.Name == m.Name)));
        }
    }
}