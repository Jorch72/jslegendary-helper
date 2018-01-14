using System.Collections.Generic;

namespace HeroDeck
{
    public class Filter
    {
        public int Players { get; set; }
        public int MaxMasterminds { get; set; }
        public int MaxVillains { get; set; }
        public int MaxHenchmen { get; set; }
        public int MaxHeroes { get; set; }
        public List<string> Editions { get; set; }
    }
}