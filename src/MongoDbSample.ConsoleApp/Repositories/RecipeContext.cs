using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDbSample.ConsoleApp.Models;

namespace MongoDbSample.ConsoleApp.Repositories
{
    public class RecipeContext
    {
        private IMongoDatabase Database;

        public RecipeContext(IConfigurationRoot config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            var client = new MongoClient(connectionString);

            Database = client.GetDatabase(config.GetSection("DatabaseName").Value);
        }

        public IMongoCollection<Recipe> Recipes => Database.GetCollection<Recipe>("recipes");
    }
}
