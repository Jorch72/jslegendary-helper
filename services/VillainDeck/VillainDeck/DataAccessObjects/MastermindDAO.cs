using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VillainDeck
{
    public class MastermindDAO : IMastermindDAO
    {
        private HttpClient _http;

        public MastermindDAO(MastermindHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Mastermind>> GetMasterminds()
        {
            var masterminds = new List<Mastermind>();

            using(var response = await _http.GetAsync("Mastermind"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetMasterminds Error: {response.ReasonPhrase}");
                    throw new Exception($"GetMasterminds Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                masterminds = JsonConvert.DeserializeObject<List<Mastermind>>(stringResponse);
            }

            return masterminds;
        }
    }
}