using System.Collections.Generic;

namespace Hero
{
    public interface IHeroDAO
    {
        List<Hero> GetHeroes();
        Hero GetHero(string name);
        Hero InsertHero(Hero hero);
        Hero UpdateHero(Hero hero);
    }
}