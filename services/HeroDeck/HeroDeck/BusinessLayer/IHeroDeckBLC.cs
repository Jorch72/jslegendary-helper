using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroDeck
{
    public interface IHeroDeckBLC
    {
        Task<List<Hero>> GetHeroes(HeroDeckPostModel postModel);
    }
}