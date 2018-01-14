using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Net.Http;

namespace Scheme
{
    public class SchemeControllerUnitTests
    {
        private SchemeController _ctrl;

        public SchemeControllerUnitTests()
        {
            var blcMock = new Mock<ISchemeBLC>();
            blcMock.Setup(b => b.GetSchemes())
                .Returns(new List<Scheme>
                {
                    new Scheme(),
                    new Scheme()
                });

            blcMock.Setup(b => b.GetScheme(It.IsAny<string>()))
                .Returns((string name) => new Scheme { Name = name });

            blcMock.Setup(b => b.PostScheme(It.IsAny<Scheme>()))
                .Returns((Scheme Scheme) => Scheme);

            blcMock.Setup(b => b.PostSchemes(It.IsAny<List<Scheme>>()))
                .Returns((List<Scheme> Schemes) => Schemes);

            _ctrl = new SchemeController(blcMock.Object);
        }

        [Fact]
        public void Get_ReturnsSchemes()
        {
            var result = _ctrl.Get();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void Get_ValidName_ReturnsScheme()
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
        public void Post_SingleScheme_ReturnsScheme()
        {
            var Scheme = new Scheme { Name = "test" };

            var result = _ctrl.Post(Scheme);

            Assert.Equal(Scheme.Name, result.Name);
        }

        [Fact]
        public void Post_MultipleSchemes_ReturnsSchemes()
        {
            var Schemes = new List<Scheme>
            {
                new Scheme { Name = "test1" },
                new Scheme { Name = "test2" }
            };

            var result = _ctrl.Post(Schemes);

            Assert.True(result.All(m => Schemes.Any(mm => mm.Name == m.Name)));
        }
    }
}