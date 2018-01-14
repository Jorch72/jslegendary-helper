using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IMastermindBLC
    {
        Task<List<Mastermind>> GetMasterminds(Filter filter, List<Rule> rules);
    }
}