using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroDeck
{
    public class HeroDeckBLC : IHeroDeckBLC
    {
        public IHeroBLC _heroBLC;

        public HeroDeckBLC(IHeroBLC heroBLC)
        {
            _heroBLC = heroBLC;
        }

        public Task<List<Hero>> GetHeroes(HeroDeckPostModel postModel)
        {
            var filter = postModel.Filter;
            var rules = postModel.Rules;
            
            return _heroBLC.GetHeroes(filter, rules);
        }
    }
}