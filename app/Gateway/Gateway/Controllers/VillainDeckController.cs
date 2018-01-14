using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateway
{
    [Route("api/[controller]")]
    public class VillainDeckController : Controller
    {
        private IVillainDeckBLC _blc;

        public VillainDeckController(IVillainDeckBLC blc)
        {
            _blc = blc;
        }

        // POST api/values
        [HttpPost]
        public async Task<VillainDeck> Post([FromBody]Filter filter)
        {
            try
            {
                return await _blc.GetVillainDeck(filter);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
