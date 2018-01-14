using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IMastermindDAO
    {
        Task<List<Mastermind>> GetMasterminds();
    }
}