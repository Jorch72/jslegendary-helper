using System.Threading.Tasks;

namespace VillainDeck
{
    public interface ISchemeBLC
    {
        Task<Scheme> GetScheme(Filter filter);
    }
}