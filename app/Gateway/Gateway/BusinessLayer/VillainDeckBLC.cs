using System.Threading.Tasks;

namespace Gateway
{
    public class VillainDeckBLC : IVillainDeckBLC
    {
        private IVillainDeckDAO _dao;
        private IFilterDAO _filterDAO;

        public VillainDeckBLC(IVillainDeckDAO dao, IFilterDAO filterDAO)
        {
            _dao = dao;
            _filterDAO = filterDAO;
        }

        public async Task<VillainDeck> GetVillainDeck(UserFilter userFilter)
        {
            var filter = await _filterDAO.GetFilter(userFilter);
            
            return await _dao.GetVillainDeck(filter);
        }
    }
}