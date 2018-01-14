using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Edition
{
    [Route("api/[controller]")]
    public class EditionController : Controller
    {
        private IEditionBLC _blc;

        public EditionController(IEditionBLC blc)
        {
            _blc = blc;
        }

        [HttpGet]
        public List<Edition> Get()
        {
            try
            {
                return _blc.GetEditions();
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpGet("{editionName}")]
        public Edition Get(string editionName)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(editionName))
                    throw new HttpRequestException("Invalid name");

                return _blc.GetEdition(editionName);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("SingleEdition")]
        public Edition Post([FromBody] Edition edition)
        {
            try
            {
                if(edition == null)
                    throw new HttpRequestException("Invalid Edition");

                return _blc.PostEdition(edition);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("MultipleEditions")]
        public List<Edition> Post([FromBody] List<Edition> editions)
        {
            try
            {
                if(editions == null || editions.Count == 0)
                    throw new HttpRequestException("Invalid Editions");

                return _blc.PostEditions(editions);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
