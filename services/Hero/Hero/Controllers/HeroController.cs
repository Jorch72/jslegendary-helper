using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hero
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private IHeroBLC _blc;

        public HeroController(IHeroBLC blc)
        {
            _blc = blc;
        }

        [HttpGet]
        public List<Hero> Get()
        {
            try
            {
                return _blc.GetHeroes();
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public Hero Get(string name)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(name))
                    throw new HttpRequestException("Invalid name");

                return _blc.GetHero(name);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("SingleHero")]
        public Hero Post([FromBody] Hero hero)
        {
            try
            {
                if(hero == null)
                    throw new HttpRequestException("Invalid Hero");

                return _blc.PostHero(hero);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [HttpPost("MultipleHeroes")]
        public List<Hero> Post([FromBody] List<Hero> heroes)
        {
            try
            {
                if(heroes == null || heroes.Count == 0)
                    throw new HttpRequestException("Invalid Heroes");

                return _blc.PostHeroes(heroes);
            }
            catch(Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
