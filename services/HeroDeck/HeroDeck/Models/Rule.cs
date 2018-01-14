namespace HeroDeck
{
    public partial class Rule
    {
        public string Deck { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? Players { get; set; }
        public int? Wounds { get; set; }
        public int? Twists { get; set; }
        public int? Bystanders { get; set; }
        internal int? Henchmen { get; set; }
        internal int? Villains { get; set; }
        internal int? Masterminds { get; set; }
        internal int? Heroes { get; set; }
    }
}