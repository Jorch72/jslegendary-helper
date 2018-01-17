using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Filter
{
    public class Filter
    {
        [BsonId]
        internal int _id { get; set; }

        [BsonElement("players")]
        public int Players { get; set; }
        
        [BsonElement("masterminds")]
        public int MaxMasterminds { get; set; }
        
        [BsonElement("villains")]
        public int MaxVillains { get; set; }
        
        [BsonElement("henchmen")]
        public int MaxHenchmen { get; set; }

        [BsonElement("heroes")]
        public int MaxHeroes { get; set; }

        public List<string> Editions { get; set; }
    }
}