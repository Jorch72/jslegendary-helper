using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public class EditionBLC : IEditionBLC
    {
        private IEditionDAO _dao;

        public EditionBLC(IEditionDAO dao)
        {
            _dao = dao;
        }

        public async Task<List<Edition>> GetEditions()
        {
            return await _dao.GetEditions();
        }
    }
}