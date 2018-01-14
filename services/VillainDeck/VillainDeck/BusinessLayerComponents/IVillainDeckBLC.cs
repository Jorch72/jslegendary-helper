using System.Threading.Tasks;

namespace VillainDeck
{
    public interface IVillainDeckBLC
    {
        Task<VillainDeck> GetVillainDeck(Filter filter);
    }
}