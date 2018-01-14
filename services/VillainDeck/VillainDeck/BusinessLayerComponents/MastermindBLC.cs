using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillainDeck
{
    public class MastermindBLC : IMastermindBLC
    {
        private IMastermindDAO _dao;
        private Random _random;

        public MastermindBLC(IMastermindDAO dao)
        {
            _dao = dao;
            _random = new Random();
        }

        public async Task<List<Mastermind>> GetMasterminds(Filter filter, List<Rule> rules)
        {
            var filteredMasterminds = await GetFilteredMasterminds(filter);
            
            var masterminds = GetMastermindsFromRules(rules, filteredMasterminds);

            while(masterminds.Count < filter.MaxMasterminds)
            {
                var randomMastermind = GetRandomMastermind(masterminds, filteredMasterminds);
                masterminds.Add(randomMastermind);
            }

            return masterminds;
        }

        public async Task<List<Mastermind>> GetFilteredMasterminds(Filter filter)
        {
            var allMasterminds = await _dao.GetMasterminds();
            var masterminds = allMasterminds.Where(m => filter.Editions.Any(e => m.Edition == e)).ToList();

            return masterminds;
        }

        public List<Mastermind> GetMastermindsFromRules(List<Rule> rules, List<Mastermind> filteredMasterminds)
        {
            var masterminds = new List<Mastermind>();

            if(rules == null || rules.Count == 0)
                return masterminds;

            var mastermindRules = rules.Where(r => 
                r.Deck == "Mastermind" &&
                r.Type == "MastermindRule").ToList();

            foreach(var rule in mastermindRules)
            {
                var mastermind = filteredMasterminds.Find(m => m.Name == rule.Name);
                if(mastermind != null && !masterminds.Any(m => m.Name == mastermind.Name))
                    masterminds.Add(mastermind);
            }

            return masterminds;
        }

        public Mastermind GetRandomMastermind(List<Mastermind> masterminds, List<Mastermind> filteredMasterminds)
        {
            var validMasterminds = filteredMasterminds.Where(f => masterminds.Any(m => m.Name == f.Name) == false).ToList();
            var index = _random.Next(validMasterminds.Count);

            return validMasterminds[index];
        }
    }
}