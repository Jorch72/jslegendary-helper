using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeroDeck
{
    public class HeroDAO : IHeroDAO
    {
        private HttpClient _http;

        public HeroDAO(HeroHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Hero>> GetHeroes()
        {
            var heroes = new List<Hero>();

            using(var response = await _http.GetAsync("Hero"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetHeros Error: {response.ReasonPhrase}");
                    throw new Exception($"GetHeros Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                heroes = JsonConvert.DeserializeObject<List<Hero>>(stringResponse);
            }

            return heroes;
        }
    }
}