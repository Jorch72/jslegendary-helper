using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillainDeck
{
    public class HenchmanBLC : IHenchmanBLC
    {
        private IHenchmanDAO _dao;
        private Random _random;

        public HenchmanBLC(IHenchmanDAO dao)
        {
            _dao = dao;
            _random = new Random();
        }

        public async Task<List<Henchman>> GetHenchmen(Filter filter, List<Rule> rules)
        {
            var filteredHenchmen = await GetFilteredHenchmen(filter);
            
            var henchmen = GetHenchmenFromRules(rules, filteredHenchmen);

            while(henchmen.Count < filter.MaxHenchmen)
            {
                var randomHenchman = GetRandomHenchman(henchmen, filteredHenchmen);
                henchmen.Add(randomHenchman);
            }

            return henchmen;
        }

        public async Task<List<Henchman>> GetFilteredHenchmen(Filter filter)
        {
            var allHenchmen = await _dao.GetHenchmen();
            var henchmen = allHenchmen.Where(m => filter.Editions.Any(e => m.Edition == e)).ToList();

            return henchmen;
        }

        public List<Henchman> GetHenchmenFromRules(List<Rule> rules, List<Henchman> filteredHenchmen)
        {
            var henchmen = new List<Henchman>();

            if(rules == null || rules.Count == 0)
                return henchmen;

            var henchmanRules = rules.Where(r => 
                r.Deck == "Villain" &&
                r.Type == "HenchmanRule").ToList().Distinct();

            foreach(var rule in henchmanRules)
            {
                var henchman = filteredHenchmen.Find(h => h.Name == rule.Name);
                if(henchman != null && !henchmen.Any(h => h.Name == henchman.Name))
                    henchmen.Add(henchman);
            }

            return henchmen;
        }

        public Henchman GetRandomHenchman(List<Henchman> henchmen, List<Henchman> filteredHenchmen)
        {
            var validHenchmen = filteredHenchmen.Where(f => henchmen.Any(m => m.Name == f.Name) == false).ToList();
            var index = _random.Next(validHenchmen.Count);

            return validHenchmen[index];
        }
    }
}