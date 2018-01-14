using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Scheme
{
    [Route("api/[controller]")]
    public class SchemeController : Controller
    {
        private ISchemeBLC _blc;

        public SchemeController(ISchemeBLC blc)
        {
            _blc = blc;
        }

        [HttpGet]
        public List<Scheme> Get()
        {
            try
            {
                return _blc.GetSchemes();
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public Scheme Get(string name)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(name))
                    throw new HttpRequestException("Invalid name");

                return _blc.GetScheme(name);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("SingleScheme")]
        public Scheme Post([FromBody] Scheme scheme)
        {
            try
            {
                if(scheme == null)
                    throw new HttpRequestException("Invalid Scheme");

                return _blc.PostScheme(scheme);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("MultipleSchemes")]
        public List<Scheme> Post([FromBody] List<Scheme> schemes)
        {
            try
            {
                if(schemes == null || schemes.Count == 0)
                    throw new HttpRequestException("Invalid Schemes");

                return _blc.PostSchemes(schemes);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
