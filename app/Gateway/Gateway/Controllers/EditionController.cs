using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateway
{
    [Route("api/[controller]")]
    public class EditionController : Controller
    {
        private IEditionBLC _blc;

        public EditionController(IEditionBLC blc)
        {
            _blc = blc;
        }

        // POST api/values
        [HttpGet]
        public async Task<List<Edition>> Get()
        {
            try
            {
                return await _blc.GetEditions();
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
