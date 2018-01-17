using System.Collections.Generic;

namespace Gateway
{
    public class Hero
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Classes { get; set; }
    }
}