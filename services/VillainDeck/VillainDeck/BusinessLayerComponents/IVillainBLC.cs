using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IVillainBLC
    {
        Task<List<Villain>> GetVillains(Filter filter, List<Rule> rules);
    }
}