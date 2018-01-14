using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroDeck
{
    public interface IHeroDAO
    {
        Task<List<Hero>> GetHeroes();
    }
}