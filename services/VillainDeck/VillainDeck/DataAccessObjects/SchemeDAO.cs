using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VillainDeck
{
    public class SchemeDAO : ISchemeDAO
    {
        private HttpClient _http;

        public SchemeDAO(SchemeHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Scheme>> GetSchemes()
        {
            var schemes = new List<Scheme>();

            using(var response = await _http.GetAsync("Scheme"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetSchemes Error: {response.ReasonPhrase}");
                    throw new Exception($"GetSchemes Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                schemes = JsonConvert.DeserializeObject<List<Scheme>>(stringResponse);
            }

            return schemes;
        }
    }
}