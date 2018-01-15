using System.Net.Http;

namespace Gateway
{
    public class FilterHttpClient : HttpClient
    {
        public FilterHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-filter.cfapps.io/api/");
        }
    }
}