using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Hero
{
    public class HeroDAO : IHeroDAO
    {
        private IMongoDatabase _database;

        public HeroDAO(IMongoClient client)
        {
            _database = client.GetDatabase("CloudFoundry_oumhg86d_nq48b1sc");
        }

        public List<Hero> GetHeroes()
        {
            var collection = _database.GetCollection<Hero>("hero");
            var filter = Builders<Hero>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }

        public Hero GetHero(string name)
        {
            var collection = _database.GetCollection<Hero>("hero");
            var builder = Builders<Hero>.Filter;
            var filter = builder.Where(m => m.Name == name);
            var result = collection.Find(filter).FirstOrDefault();

            return result;
        }

        public Hero InsertHero(Hero hero)
        {
            var collection = _database.GetCollection<Hero>("hero");
            collection.InsertOne(hero);

            return hero;
        }

        public Hero UpdateHero(Hero hero)
        {
            var collection = _database.GetCollection<Hero>("hero");
            var builder = Builders<Hero>.Filter;
            var filter = builder.Where(m => m.Name == hero.Name);
            var update = Builders<Hero>.Update
                .Set("name", hero.Name)
                .Set("edition", hero.Edition)
                .Set("teams", hero.Teams)
                .Set("classes", hero.Classes);
                
            collection.UpdateOne(filter, update);
            
            return hero;
        }
    }
}