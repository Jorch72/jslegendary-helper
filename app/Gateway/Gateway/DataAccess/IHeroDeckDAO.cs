using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public interface IHeroDeckDAO
    {
        Task<List<Hero>> GetHeroDeck(HeroDeckPostModel heroDeckPost);
    }
}