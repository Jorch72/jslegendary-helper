using System.Collections.Generic;

namespace Gateway
{
    public class Card
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public List<Rule> Rules { get; set; }
    }
}