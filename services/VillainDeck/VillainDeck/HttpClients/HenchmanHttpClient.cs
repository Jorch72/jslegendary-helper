using System.Net.Http;

namespace VillainDeck
{
    public class HenchmanHttpClient : HttpClient
    {
        public HenchmanHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-henchman.cfapps.io/api/");
        }
    }
}