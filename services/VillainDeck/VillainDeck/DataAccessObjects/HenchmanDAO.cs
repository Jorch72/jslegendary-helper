using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VillainDeck
{
    public class HenchmanDAO : IHenchmanDAO
    {
        private HttpClient _http;

        public HenchmanDAO(HenchmanHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Henchman>> GetHenchmen()
        {
            var henchmen = new List<Henchman>();

            using(var response = await _http.GetAsync("Henchman"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetHenchmen Error: {response.ReasonPhrase}");
                    throw new Exception($"GetHenchmen Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                henchmen = JsonConvert.DeserializeObject<List<Henchman>>(stringResponse);
            }

            return henchmen;
        }
    }
}