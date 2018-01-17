using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace Hero
{
    public class HeroBLCUnitTests
    {
        private Mock<IHeroDAO> _mockDAO;
        private HeroBLC _blc;

        public HeroBLCUnitTests()
        {
            _mockDAO = new Mock<IHeroDAO>();
            _blc = new HeroBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetHeroes_ReturnsHeroes()
        {
            _mockDAO.Setup(m => m.GetHeroes()).Returns(new List<Hero>());

            var result = _blc.GetHeroes();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetHero_ValidName_ReturnsHero()
        {
            _mockDAO.Setup(m => m.GetHero(It.IsAny<string>())).Returns(new Hero());

            var result = _blc.GetHero("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void PostHero_ExistingHero_UpdatesHero()
        {
            var hero = new Hero();
            _mockDAO.Setup(m => m.GetHero(It.IsAny<string>())).Returns(hero);

            var result = _blc.PostHero(hero);

            _mockDAO.Verify(m => m.UpdateHero(hero));
        }

        [Fact]
        public void PostHero_NewHero_InsertsHero()
        {
            var hero = new Hero();
            _mockDAO.Setup(m => m.GetHero(It.IsAny<string>())).Returns((Hero)null);

            var result = _blc.PostHero(hero);

            _mockDAO.Verify(m => m.InsertHero(hero));
        }

        [Fact]
        public void PostHeroes_ExistingHero_UpdatesHero()
        {
            var hero = new Hero();
            var heroes = new List<Hero> { hero };
            _mockDAO.Setup(m => m.GetHero(It.IsAny<string>())).Returns(hero);

            var result = _blc.PostHeroes(heroes);

            _mockDAO.Verify(m => m.UpdateHero(hero));
        }

        [Fact]
        public void PostHeroes_NewHero_InsertsHero()
        {
            var hero = new Hero();
            var heroes = new List<Hero> { hero };
            _mockDAO.Setup(m => m.GetHero(It.IsAny<string>())).Returns((Hero)null);

            var result = _blc.PostHeroes(heroes);

            _mockDAO.Verify(m => m.InsertHero(hero));
        }
    }
}