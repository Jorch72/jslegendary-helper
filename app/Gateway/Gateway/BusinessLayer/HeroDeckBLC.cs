using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public class HeroDeckBLC : IHeroDeckBLC
    {
        private IHeroDeckDAO _dao;

        public HeroDeckBLC(IHeroDeckDAO dao)
        {
            _dao = dao;
        }

        public async Task<List<Hero>> GetHeroDeck(HeroDeckPostModel heroDeckPost)
        {
            return await _dao.GetHeroDeck(heroDeckPost);
        }
    }
}