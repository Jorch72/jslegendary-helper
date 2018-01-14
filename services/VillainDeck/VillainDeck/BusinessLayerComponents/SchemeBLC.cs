using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillainDeck
{
    public class SchemeBLC : ISchemeBLC
    {
        private ISchemeDAO _dao;
        private Random _random;

        public SchemeBLC(ISchemeDAO dao)
        {
            _dao = dao;
            _random = new Random();
        }

        public async Task<Scheme> GetScheme(Filter filter)
        {
            var filteredSchemes = await GetFilteredSchemes(filter);

            var index = _random.Next(filteredSchemes.Count);

            return filteredSchemes[index];
        }

        public async Task<List<Scheme>> GetFilteredSchemes(Filter filter)
        {
            var allSchemes = await _dao.GetSchemes();
            var schemes = allSchemes.Where(m => filter.Editions.Any(e => m.Edition == e)).ToList();

            return schemes;
        }
    }
}