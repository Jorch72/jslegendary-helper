using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Edition
{
    public class EditionDAO : IEditionDAO
    {
        private IMongoDatabase _database;

        public EditionDAO(IMongoClient client)
        {
            _database = client.GetDatabase("CloudFoundry_oumhg86d_nq48b1sc");
        }

        public List<Edition> GetEditions()
        {
            var collection = _database.GetCollection<Edition>("edition");
            var filter = Builders<Edition>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }

        public Edition GetEdition(string editionName)
        {
            var collection = _database.GetCollection<Edition>("edition");
            var builder = Builders<Edition>.Filter;
            var filter = builder.Where(e => e.Name == editionName);
            var result = collection.Find(filter).FirstOrDefault();

            return result;
        }

        public Edition InsertEdition(Edition edition)
        {
            var collection = _database.GetCollection<Edition>("edition");
            collection.InsertOne(edition);

            return edition;
        }

        public Edition UpdateEdition(Edition edition)
        {
            var collection = _database.GetCollection<Edition>("edition");
            var builder = Builders<Edition>.Filter;
            var filter = builder.Where(e => e.Id == edition.Id);
            var update = Builders<Edition>.Update
                .Set("name", edition.Name);
                
            collection.UpdateOne(filter, update);
            
            return edition;
        }
    }
}