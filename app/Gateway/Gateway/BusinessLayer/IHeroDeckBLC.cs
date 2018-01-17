using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public interface IHeroDeckBLC
    {
        Task<List<Hero>> GetHeroDeck(HeroDeckPostModel heroDeckPost);   
    }
}