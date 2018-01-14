using System.Net.Http;

namespace Gateway
{
    public class EditionHttpClient : HttpClient
    {
        public EditionHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-edition.cfapps.io/api/");
        }
    }
}