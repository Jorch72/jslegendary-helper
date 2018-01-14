using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IHenchmanBLC
    {
        Task<List<Henchman>> GetHenchmen(Filter filter, List<Rule> rules);
    }
}