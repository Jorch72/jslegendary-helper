using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Filter
{
    public class FilterDAO : IFilterDAO
    {
        private IMongoDatabase _database;

        public FilterDAO(IMongoClient client)
        {
            _database = client.GetDatabase("CloudFoundry_oumhg86d_nq48b1sc");
        }

        public Filter GetFilter(int players)
        {
            var collection = _database.GetCollection<Filter>("filter");
            var builder = Builders<Filter>.Filter;
            var filter = builder.Where(f => f.Players == players);
            var result = collection.Find(filter).FirstOrDefault();

            return result;
        }

        public List<Filter> GetFilters()
        {
            var collection = _database.GetCollection<Filter>("filter");
            var filter = Builders<Filter>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }
    }
}