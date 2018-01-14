using System.Net.Http;

namespace Gateway
{
    public class VillainDeckHttpClient : HttpClient
    {
        public VillainDeckHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-villain-deck.cfapps.io/api/");
        }
    }
}