using System.Net.Http;

namespace Gateway
{
    public class HeroDeckHttpClient : HttpClient
    {
        public HeroDeckHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-hero-deck.cfapps.io/api/");
        }
    }
}