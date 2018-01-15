using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gateway
{
    public class FilterDAO : IFilterDAO
    {
        private HttpClient _http;

        public FilterDAO(FilterHttpClient http)
        {
            _http = http;
        }

        public async Task<Filter> GetFilter(UserFilter userFilter)
        {
            var filter = new Filter();

            var jsonContent = JsonConvert.SerializeObject(userFilter);
            var content = new StringContent(jsonContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using(var response = await _http.PostAsync("Filter", content))
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"GetFilter Error: {response.ReasonPhrase}");
                    throw new Exception($"GetFilter Error: {response.ReasonPhrase}");
                }
                    
                var stringResponse = await response.Content.ReadAsStringAsync();
                filter = JsonConvert.DeserializeObject<Filter>(stringResponse);
            }

            return filter;
        }
    }
}