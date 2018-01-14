using System.Threading.Tasks;

namespace Gateway
{
    public interface IVillainDeckDAO
    {
        Task<VillainDeck> GetVillainDeck(Filter filter);
    }
}