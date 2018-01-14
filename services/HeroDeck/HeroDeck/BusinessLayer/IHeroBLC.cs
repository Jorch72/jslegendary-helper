using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroDeck
{
    public interface IHeroBLC
    {
        Task<List<Hero>> GetHeroes(Filter filter, List<Rule> rules);
    }
}