using System.Collections.Generic;

namespace Gateway
{
    public class VillainDeck
    {
        public Filter Filter { get; set; }
        public Scheme Scheme { get; set; }
        public List<Mastermind> Masterminds { get; set; }
        public List<Villain> Villains { get; set; }
        public List<Henchman> Henchmen { get; set; }
    }
}