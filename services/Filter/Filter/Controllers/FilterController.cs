using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Filter
{
    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        private IFilterBLC _blc;

        public FilterController(IFilterBLC blc)
        {
            _blc = blc;
        }

        // POST api/values
        [HttpPost]
        public Filter Post([FromBody] UserFilter userFilter)
        {
            try
            {
                return _blc.GetFilter(userFilter);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
