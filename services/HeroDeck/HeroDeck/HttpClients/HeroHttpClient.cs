using System.Net.Http;

namespace HeroDeck
{
    public class HeroHttpClient : HttpClient
    {
        public HeroHttpClient()
        {
            BaseAddress = new System.Uri("https://legendary-hero.cfapps.io/api/");
        }
    }
}