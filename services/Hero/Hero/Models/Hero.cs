using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hero
{
    public class Hero
    {
        [BsonId] 
        internal ObjectId _id { get; set; }
        
        [BsonElement("name")] 
        public string Name { get; set; }
        
        [BsonElement("edition")] 
        public string Edition { get; set; }
        
        [BsonElement("teams")]
        public List<string> Teams { get; set; }
        
        [BsonElement("classes")]
        public List<string> Classes { get; set; }
    }
}