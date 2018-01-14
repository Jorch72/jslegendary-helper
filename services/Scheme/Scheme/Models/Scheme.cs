using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Scheme
{
    public class Scheme
    {
        [BsonId] 
        internal ObjectId _id { get; set; }
        
        [BsonElement("name")] 
        public string Name { get; set; }
        
        [BsonElement("edition")] 
        public string Edition { get; set; }
        
        [BsonElement("rules")]
        public List<Rule> Rules { get; set; }
    }
}