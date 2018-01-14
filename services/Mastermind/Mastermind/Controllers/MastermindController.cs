using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mastermind
{
    [Route("api/[controller]")]
    public class MastermindController : Controller
    {
        private IMastermindBLC _blc;

        public MastermindController(IMastermindBLC blc)
        {
            _blc = blc;
        }

        [HttpGet]
        public List<Mastermind> Get()
        {
            try
            {
                return _blc.GetMasterminds();
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public Mastermind Get(string name)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(name))
                    throw new HttpRequestException("Invalid name");

                return _blc.GetMastermind(name);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("SingleMastermind")]
        public Mastermind Post([FromBody] Mastermind mastermind)
        {
            try
            {
                if(mastermind == null)
                    throw new HttpRequestException("Invalid mastermind");

                return _blc.PostMastermind(mastermind);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("MultipleMasterminds")]
        public List<Mastermind> Post([FromBody] List<Mastermind> masterminds)
        {
            try
            {
                if(masterminds == null || masterminds.Count == 0)
                    throw new HttpRequestException("Invalid masterminds");

                return _blc.PostMasterminds(masterminds);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
