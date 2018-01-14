using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillainDeck
{
    public class VillainBLC : IVillainBLC
    {
        private IVillainDAO _dao;
        private Random _random;

        public VillainBLC(IVillainDAO dao)
        {
            _dao = dao;
            _random = new Random();
        }

        public async Task<List<Villain>> GetVillains(Filter filter, List<Rule> rules)
        {
            var filteredVillains = await GetFilteredVillains(filter);
            
            var villains = GetVillainsFromRules(rules, filteredVillains);

            while(villains.Count < filter.MaxVillains)
            {
                var randomVillain = GetRandomVillain(villains, filteredVillains);
                villains.Add(randomVillain);
            }

            return villains;
        }

        public async Task<List<Villain>> GetFilteredVillains(Filter filter)
        {
            var allVillains = await _dao.GetVillains();
            var villains = allVillains.Where(m => filter.Editions.Any(e => m.Edition == e)).ToList();

            return villains;
        }

        public List<Villain> GetVillainsFromRules(List<Rule> rules, List<Villain> filteredVillains)
        {
            var villains = new List<Villain>();

            if(rules == null || rules.Count == 0)
                return villains;

            var villainRules = rules.Where(r => 
                r.Deck == "Villain" &&
                r.Type == "VillainRule").ToList().Distinct();

            foreach(var rule in villainRules)
            {
                var villain = filteredVillains.Find(m => m.Name == rule.Name);
                if(villain != null && !villains.Any(v => v.Name == villain.Name))
                    villains.Add(villain);
            }

            return villains;
        }

        public Villain GetRandomVillain(List<Villain> villains, List<Villain> filteredVillains)
        {
            var validVillains = filteredVillains.Where(f => villains.Any(m => m.Name == f.Name) == false).ToList();
            var index = _random.Next(validVillains.Count);

            return validVillains[index];
        }
    }
}