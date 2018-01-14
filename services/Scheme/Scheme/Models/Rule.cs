using MongoDB.Bson.Serialization.Attributes;

namespace Scheme
{
    public partial class Rule
    {
        [BsonElement("deck")]
        public string Deck { get; set; }
        
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("amount")]
        public int? Amount { get; set; }

        [BsonElement("players")]
        public int? Players { get; set; }

        [BsonElement("wounds")]
        public int? Wounds { get; set; }

        [BsonElement("twists")]
        public int? Twists { get; set; }

        [BsonElement("bystanders")]
        public int? Bystanders { get; set; }

        [BsonElement("henchmen")]
        public int? Henchmen { get; set; }

        [BsonElement("villains")]
        public int? Villains { get; set; }

        [BsonElement("masterminds")]
        public int? Masterminds { get; set; }

        [BsonElement("heroes")]
        public int? Heroes { get; set; }
    }
}