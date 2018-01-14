using System.Net.Http;

namespace VillainDeck
{
    public class SchemeHttpClient : HttpClient
    {
        public SchemeHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-scheme.cfapps.io/api/");
        }
    }
}