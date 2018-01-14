using System.Threading.Tasks;

namespace Gateway
{
    public class VillainDeckBLC : IVillainDeckBLC
    {
        private IVillainDeckDAO _dao;

        public VillainDeckBLC(IVillainDeckDAO dao)
        {
            _dao = dao;
        }

        public async Task<VillainDeck> GetVillainDeck(Filter filter)
        {
            return await _dao.GetVillainDeck(filter);
        }
    }
}