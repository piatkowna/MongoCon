using MongoCon.Models;
using MongoCon.Properties;
using MongoDB.Driver;
using System.Configuration;

namespace MongoCon.App_Start
{
    public class DbContext
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public DbContext()
        {
            _client = new MongoClient(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            _database = _client.GetDatabase(Settings.Default.MainDbName);
        }

        public IMongoCollection<Person> People
        {
            get
            {
                return _database.GetCollection<Person>("people");
            }
        }
    }
}