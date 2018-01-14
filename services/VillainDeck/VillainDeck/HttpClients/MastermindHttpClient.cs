using System.Net.Http;

namespace VillainDeck
{
    public class MastermindHttpClient : HttpClient
    {
        public MastermindHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-mastermind.cfapps.io/api/");
        }
    }
}