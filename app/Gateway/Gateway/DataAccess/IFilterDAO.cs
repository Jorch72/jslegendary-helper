using System.Threading.Tasks;

namespace Gateway
{
    public interface IFilterDAO
    {
        Task<Filter> GetFilter(UserFilter userFilter);
    }
}