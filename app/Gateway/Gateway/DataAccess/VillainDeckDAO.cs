using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gateway
{
    public class VillainDeckDAO : IVillainDeckDAO
    {
        private HttpClient _http;

        public VillainDeckDAO(VillainDeckHttpClient http)
        {
            _http = http;
        }

        public async Task<VillainDeck> GetVillainDeck(Filter filter)
        {
            var villainDeck = new VillainDeck();

            var jsonContent = JsonConvert.SerializeObject(filter);
            var content = new StringContent(jsonContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using(var response = await _http.PostAsync("VillainDeck", content))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetVillainDeck Error: {response.ReasonPhrase}");
                    throw new Exception($"GetVillainDeck Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                villainDeck = JsonConvert.DeserializeObject<VillainDeck>(stringResponse);
            }

            return villainDeck;
        }
    }
}