using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDbSample.ConsoleApp.Repositories;
using MongoDbSample.ConsoleApp.Repositories.Interfaces;
using System;
using System.IO;

namespace MongoDbSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Application app = serviceProvider.GetService<Application>();

            app.Run();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTransient<RecipeContext>();
            serviceCollection.AddTransient<Application>();
            serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();

            return serviceCollection;
        }
    }
}
