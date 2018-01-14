using System.Net.Http;

namespace VillainDeck
{
    public class VillainHttpClient : HttpClient
    {
        public VillainHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-villain.cfapps.io/api/");
        }
    }
}