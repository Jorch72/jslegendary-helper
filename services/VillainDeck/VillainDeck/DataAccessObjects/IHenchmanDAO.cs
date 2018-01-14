using System.Collections.Generic;
using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IHenchmanDAO
    {
        Task<List<Henchman>> GetHenchmen();
    }
}