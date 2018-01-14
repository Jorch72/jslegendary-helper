using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillainDeck
{
    public class VillainDeckBLC : IVillainDeckBLC
    {
        private ISchemeBLC _schemeBLC;
        private IMastermindBLC _mastermindBLC;
        private IVillainBLC _villainBLC;
        private IHenchmanBLC _henchmanBLC;

        public VillainDeckBLC(ISchemeBLC schemeBLC,
            IMastermindBLC mastermindBLC,
            IVillainBLC villainBLC,
            IHenchmanBLC henchmanBLC)
        {
            _schemeBLC = schemeBLC;
            _mastermindBLC = mastermindBLC;
            _villainBLC = villainBLC;
            _henchmanBLC = henchmanBLC;
        }

        public async Task<VillainDeck> GetVillainDeck(Filter filter)
        {
            var rules = new List<Rule>();

            var scheme = await _schemeBLC.GetScheme(filter);
            Console.WriteLine($"Scheme: {scheme.Name}");
            rules = AddRules(rules, scheme);

            filter = ApplySetupRules(filter, scheme);

            var masterminds = await _mastermindBLC.GetMasterminds(filter, rules);
            foreach(var mastermind in masterminds)
            {
                Console.WriteLine($"Mastermind: {mastermind.Name}");
                rules = AddRules(rules, mastermind);
            }
            
            var villains = await _villainBLC.GetVillains(filter, rules);
            foreach(var villain in villains)
            {
                Console.WriteLine($"Villain: {villain.Name}");
                rules = AddRules(rules, villain);
            }

            var henchmen = await _henchmanBLC.GetHenchmen(filter, rules);
            foreach(var henchman in henchmen)
            {
                Console.WriteLine($"Henchman: {henchman.Name}");
                rules = AddRules(rules, henchman);
            }


            var villainDeck = new VillainDeck
            {
                Filter = filter,
                Scheme = scheme,
                Masterminds = masterminds,
                Villains = villains,
                Henchmen = henchmen
            };

            return villainDeck;
        }

        public Filter ApplySetupRules(Filter filter, Scheme scheme)
        {
            if(scheme.Rules == null || scheme.Rules.Count == 0)
                return filter;
                
            var setupRule = scheme.Rules.Where(r => 
                r.Type == "SetupRule" && 
                r.Players == filter.Players)
                .FirstOrDefault();

            if(setupRule == null)
                return filter;

            if(setupRule.Masterminds != null)
                filter.MaxMasterminds = setupRule.Masterminds.Value;
            if(setupRule.Villains != null)
                filter.MaxVillains = setupRule.Villains.Value;

            return filter;
        }

        public List<Rule> AddRules(List<Rule> rules, Card card)
        {
            if(card.Rules != null)
                rules.AddRange(card.Rules);

            return rules;
        }
    }
}