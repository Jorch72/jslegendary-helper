using System.Collections.Generic;

namespace Hero
{
    public interface IHeroBLC
    {
        List<Hero> GetHeroes();
        Hero GetHero(string name);
        Hero PostHero(Hero hero);
        List<Hero> PostHeroes(List<Hero> heroes);
    }
}