using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeroDeck
{
    [Route("api/[controller]")]
    public class HeroDeckController : Controller
    {
        private IHeroDeckBLC _blc;

        public HeroDeckController(IHeroDeckBLC blc)
        {
            _blc = blc;
        }

        [HttpPost]
        public async Task<List<Hero>> Post([FromBody]HeroDeckPostModel postModel)
        {
            return await _blc.GetHeroes(postModel);
        }
    }
}
