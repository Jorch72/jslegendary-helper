using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VillainDeck
{
    [Route("api/[controller]")]
    public class VillainDeckController : Controller
    {
        private IVillainDeckBLC _blc;

        public VillainDeckController(IVillainDeckBLC blc)
        {
            _blc = blc;
        }

        [HttpPost]
        public async Task<VillainDeck> PostAsync([FromBody] Filter filter)
        {
            try
            {
                if(filter == null)
                    throw new HttpRequestException("Invalid filter data");
                    
                return await _blc.GetVillainDeck(filter);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
