using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Hero
{
    public class HeroBLCUnitTests
    {
        private const string NEW = "new";
        private const string EXISTING = "existing";
        private HeroBLC _blc;

        public HeroBLCUnitTests()
        {
            var daoMock = new Mock<IHeroDAO>();
            daoMock.Setup(d => d.GetHeroes())
                .Returns(new List<Hero>
                {
                    new Hero(),
                    new Hero()
                });

            daoMock.Setup(d => d.GetHero(It.IsAny<string>()))
                .Returns((string name) => 
                {
                    if(name == NEW)
                        return null;
                    else
                        return new Hero 
                            {  
                                Name = name,
                                Edition = "oldEdition"
                            };
                });

            daoMock.Setup(d => d.InsertHero(It.IsAny<Hero>()))
                .Returns((Hero hero) => hero);

            daoMock.Setup(d => d.UpdateHero(It.IsAny<Hero>()))
                .Returns((Hero hero) => hero);

            _blc = new HeroBLC(daoMock.Object);
        }

        [Fact]
        public void GetHeroes_ReturnsHeroes()
        {
            var result = _blc.GetHeroes();

            Assert.True(result.Count > 1);
        }

        [Fact]
        public void GetHero_ValidName_ReturnsHero()
        {
            var result = _blc.GetHero(EXISTING);

            Assert.Equal(EXISTING, result.Name);
        }

        [Fact]
        public void PostHero_ExistingHero_UpdatesHero()
        {
            var hero = new Hero
            {
                Name = EXISTING,
                Edition = "newEdition"
            };

            var result = _blc.PostHero(hero);

            Assert.Equal(hero.Edition, result.Edition);
        }

        [Fact]
        public void PostHero_NewHero_InsertsHero()
        {
            var hero = new Hero
            {
                Name = NEW
            };

            var result = _blc.PostHero(hero);

            Assert.Equal(hero.Name, result.Name);
        }

        [Fact]
        public void PostHeroes_NewAndExistingHeroes_InsertsAndUpdatesHeroes()
        {
            var heroes = new List<Hero>
            {
                new Hero { Name = NEW, Edition = "Core" },
                new Hero { Name = EXISTING, Edition = "Core" }
            };

            var result = _blc.PostHeroes(heroes);

            Assert.True(result.All(m => heroes.Any(mm => mm.Name == m.Name)));
        }
    }
}