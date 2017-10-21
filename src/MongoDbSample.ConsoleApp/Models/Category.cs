using System;

namespace MongoDbSample.ConsoleApp.Models
{
    public class Category
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
