using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateway
{
    [Route("api/[controller]")]
    public class HeroDeckController : Controller
    {
        private IHeroDeckBLC _blc;

        public HeroDeckController(IHeroDeckBLC blc)
        {
            _blc = blc;
        }

        // POST api/values
        [HttpPost]
        public async Task<List<Hero>> Post([FromBody]HeroDeckPostModel heroDeckPost)
        {
            try
            {
                return await _blc.GetHeroDeck(heroDeckPost);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
