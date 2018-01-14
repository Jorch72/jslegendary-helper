using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VillainDeck
{
    public class VillainDAO : IVillainDAO
    {
        private HttpClient _http;

        public VillainDAO(VillainHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Villain>> GetVillains()
        {
            var villains = new List<Villain>();

            using(var response = await _http.GetAsync("Villain"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetVillains Error: {response.ReasonPhrase}");
                    throw new Exception($"GetVillains Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                villains = JsonConvert.DeserializeObject<List<Villain>>(stringResponse);
            }

            return villains;
        }
    }
}