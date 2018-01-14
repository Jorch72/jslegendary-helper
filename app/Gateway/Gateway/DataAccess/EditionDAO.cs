using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gateway
{
    public class EditionDAO : IEditionDAO
    {
        private HttpClient _http;

        public EditionDAO(EditionHttpClient http)
        {
            _http = http;
        }

        public async Task<List<Edition>> GetEditions()
        {
            var editions = new List<Edition>();

            using(var response = await _http.GetAsync("Edition"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetEditions Error: {response.ReasonPhrase}");
                    throw new Exception($"GetEditions Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                editions = JsonConvert.DeserializeObject<List<Edition>>(stringResponse);
            }

            return editions;
        }
    }
}