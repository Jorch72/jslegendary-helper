using System.Collections.Generic;

namespace Gateway
{
    public class HeroDeckPostModel
    {
        public Filter Filter { get; set; }
        public List<Rule> Rules { get; set; }
    }
}