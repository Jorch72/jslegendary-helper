using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IVillainDAO
    {
        Task<List<Villain>> GetVillains();
    }
}