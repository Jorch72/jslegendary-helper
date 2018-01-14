using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroDeck
{
    public class HeroBLC : IHeroBLC
    {
        private IHeroDAO _dao;
        private Random _random;

        public HeroBLC(IHeroDAO dao)
        {
            _dao = dao;
            _random = new Random();
        }

        public async Task<List<Hero>> GetHeroes(Filter filter, List<Rule> rules)
        {
            var filteredHeroes = await GetFilteredHeroes(filter);
            
            var heroes = GetHeroesFromRules(rules, filteredHeroes, filter);

            while(heroes.Count < filter.MaxHeroes)
            {
                var randomHero = GetRandomHero(heroes, filteredHeroes);
                heroes.Add(randomHero);
            }

            return heroes;
        }

        public async Task<List<Hero>> GetFilteredHeroes(Filter filter)
        {
            var allHeroes = await _dao.GetHeroes();
            var heroes = allHeroes.Where(m => filter.Editions.Any(e => m.Edition == e)).ToList();

            return heroes;
        }

        public List<Hero> GetHeroesFromRules(List<Rule> rules, List<Hero> filteredHeroes, Filter filter)
        {
            var heroes = new List<Hero>();

            if(rules == null || rules.Count == 0)
                return heroes;

            var heroRules = rules.Where(r => 
                r.Deck == "Hero" &&
                r.Type == "HeroRule").ToList();

            foreach(var rule in heroRules)
            {
                var hero = filteredHeroes.Find(m => m.Name == rule.Name);
                if(hero != null && !heroes.Any(m => m.Name == hero.Name))
                    heroes.Add(hero);
            }

            var teamRules = rules.Where(r => 
                r.Deck == "Hero" &&
                r.Type == "TeamRule").ToList();

            foreach(var rule in teamRules)
            {
                var currentTeamCount = heroes.Where(h => h.Teams.Contains(rule.Name)).Count();
                while(currentTeamCount < rule.Amount && 
                    heroes.Count < filter.MaxHeroes)
                    {
                        currentTeamCount++;
                        var teamHeroes = filteredHeroes.Where(f => 
                            f.Teams.Contains(rule.Name) &&
                            !heroes.Any(h => h.Name == f.Name)).ToList();

                        var index = _random.Next(teamHeroes.Count);
                        heroes.Add(teamHeroes[index]);
                    }
            }

            var classRules = rules.Where(r => 
                r.Deck == "Hero" &&
                r.Type == "ClassRule").ToList();

            foreach(var rule in classRules)
            {
                var currentClassCount = heroes.Where(h => h.Classes.Contains(rule.Name)).Count();
                while(currentClassCount < rule.Amount &&
                    heroes.Count < filter.MaxHeroes)
                    {
                        currentClassCount++;
                        var classHeroes = filteredHeroes.Where(f =>
                            f.Classes.Contains(rule.Name) &&
                            !heroes.Any(h => h.Name == f.Name)).ToList();

                        var index = _random.Next(classHeroes.Count);
                        heroes.Add(classHeroes[index]);
                    }
            }

            return heroes;
        }

        public Hero GetRandomHero(List<Hero> heroes, List<Hero> filteredHeroes)
        {
            var validHeroes = filteredHeroes.Where(f => heroes.Any(m => m.Name == f.Name) == false).ToList();
            var index = _random.Next(validHeroes.Count);

            return validHeroes[index];
        }
    }
}