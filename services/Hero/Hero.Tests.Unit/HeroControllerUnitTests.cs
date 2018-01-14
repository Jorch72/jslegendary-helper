using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Net.Http;

namespace Hero
{
    public class HeroControllerUnitTests
    {
        private HeroController _ctrl;

        public HeroControllerUnitTests()
        {
            var blcMock = new Mock<IHeroBLC>();
            blcMock.Setup(b => b.GetHeroes())
                .Returns(new List<Hero>
                {
                    new Hero(),
                    new Hero()
                });

            blcMock.Setup(b => b.GetHero(It.IsAny<string>()))
                .Returns((string name) => new Hero { Name = name });

            blcMock.Setup(b => b.PostHero(It.IsAny<Hero>()))
                .Returns((Hero hero) => hero);

            blcMock.Setup(b => b.PostHeroes(It.IsAny<List<Hero>>()))
                .Returns((List<Hero> heroes) => heroes);

            _ctrl = new HeroController(blcMock.Object);
        }

        [Fact]
        public void Get_ReturnsHeroes()
        {
            var result = _ctrl.Get();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void Get_ValidName_ReturnsHero()
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
        public void Post_SingleHero_ReturnsHero()
        {
            var hero = new Hero { Name = "test" };

            var result = _ctrl.Post(hero);

            Assert.Equal(hero.Name, result.Name);
        }

        [Fact]
        public void Post_MultipleHeroes_ReturnsHeroes()
        {
            var heroes = new List<Hero>
            {
                new Hero { Name = "test1" },
                new Hero { Name = "test2" }
            };

            var result = _ctrl.Post(heroes);

            Assert.True(result.All(m => heroes.Any(mm => mm.Name == m.Name)));
        }
    }
}