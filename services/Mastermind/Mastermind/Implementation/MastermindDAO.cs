using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Mastermind
{
    public class MastermindDAO : IMastermindDAO
    {
        private IMongoDatabase _database;

        public MastermindDAO(IMongoClient client)
        {
            _database = client.GetDatabase("CloudFoundry_oumhg86d_nq48b1sc");
        }

        public Mastermind GetMastermind(string name)
        {
            var collection = _database.GetCollection<Mastermind>("mastermind");
            var builder = Builders<Mastermind>.Filter;
            var filter = builder.Where(m => m.Name == name);
            var result = collection.Find(filter).FirstOrDefault();

            return result;
        }

        public List<Mastermind> GetMasterminds()
        {
            var collection = _database.GetCollection<Mastermind>("mastermind");
            var filter = Builders<Mastermind>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }

        public Mastermind InsertMastermind(Mastermind mastermind)
        {
            var collection = _database.GetCollection<Mastermind>("mastermind");
            collection.InsertOne(mastermind);

            return mastermind;
        }

        public Mastermind UpdateMastermind(Mastermind mastermind)
        {
            var collection = _database.GetCollection<Mastermind>("mastermind");
            var builder = Builders<Mastermind>.Filter;
            var filter = builder.Where(m => m.Name == mastermind.Name);
            var update = Builders<Mastermind>.Update
                .Set("name", mastermind.Name)
                .Set("edition", mastermind.Edition)
                .Set("rules", mastermind.Rules);
                
            collection.UpdateOne(filter, update);
            
            return mastermind;
        }
    }
}