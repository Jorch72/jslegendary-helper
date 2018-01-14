using System.Collections.Generic;

namespace Hero
{
    public class HeroBLC : IHeroBLC
    {
        private IHeroDAO _dao;

        public HeroBLC(IHeroDAO dao)
        {
            _dao = dao;
        }

        public List<Hero> GetHeroes()
        {
            return _dao.GetHeroes();
        }

        public Hero GetHero(string name)
        {
            return _dao.GetHero(name);
        }

        public Hero PostHero(Hero hero)
        {
            var result = _dao.GetHero(hero.Name);

            if(result == null)
                return _dao.InsertHero(hero);
            else
                return _dao.UpdateHero(hero);
        }
        
        public List<Hero> PostHeroes(List<Hero> heroes)
        {
            var result = new List<Hero>();

            foreach(var hero in heroes)
            {
                var exists = _dao.GetHero(hero.Name);

                if(exists == null)
                    result.Add(_dao.InsertHero(hero));
                else
                    result.Add(_dao.UpdateHero(hero));
            }

            return result;
        }
    }
}