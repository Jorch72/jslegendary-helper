using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Scheme
{
    public class SchemeDAO : ISchemeDAO
    {
        private IMongoDatabase _database;

        public SchemeDAO(IMongoClient client)
        {
            _database = client.GetDatabase("CloudFoundry_oumhg86d_nq48b1sc");
        }

        public List<Scheme> GetSchemes()
        {
            var collection = _database.GetCollection<Scheme>("scheme");
            var filter = Builders<Scheme>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }

        public Scheme GetScheme(string name)
        {
            var collection = _database.GetCollection<Scheme>("scheme");
            var builder = Builders<Scheme>.Filter;
            var filter = builder.Where(m => m.Name == name);
            var result = collection.Find(filter).FirstOrDefault();

            return result;
        }

        public Scheme InsertScheme(Scheme scheme)
        {
            var collection = _database.GetCollection<Scheme>("scheme");
            collection.InsertOne(scheme);

            return scheme;
        }

        public Scheme UpdateScheme(Scheme scheme)
        {
            var collection = _database.GetCollection<Scheme>("scheme");
            var builder = Builders<Scheme>.Filter;
            var filter = builder.Where(m => m.Name == scheme.Name);
            var update = Builders<Scheme>.Update
                .Set("name", scheme.Name)
                .Set("edition", scheme.Edition)
                .Set("rules", scheme.Rules);
                
            collection.UpdateOne(filter, update);
            
            return scheme;
        }
    }
}