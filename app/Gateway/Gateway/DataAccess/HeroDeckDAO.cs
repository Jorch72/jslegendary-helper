using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gateway
{
    public class HeroDeckDAO : IHeroDeckDAO
    {
        private HttpClient _http;
        public HeroDeckDAO(HeroDeckHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Hero>> GetHeroDeck(HeroDeckPostModel heroDeckPost)
        {
            var heroDeck = new List<Hero>();

            var jsonContent = JsonConvert.SerializeObject(heroDeckPost);
            var content = new StringContent(jsonContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using(var response = await _http.PostAsync("HeroDeck", content))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetHeroDeck Error: {response.ReasonPhrase}");
                    throw new Exception($"GetHeroDeck Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                heroDeck = JsonConvert.DeserializeObject<List<Hero>>(stringResponse);
            }

            return heroDeck;
        }
    }
}