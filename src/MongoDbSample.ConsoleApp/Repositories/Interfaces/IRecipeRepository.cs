using MongoDbSample.ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace MongoDbSample.ConsoleApp.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe GetById(Guid recipeId);

        IEnumerable<Recipe> Get();

        IEnumerable<Recipe> Search(string criteria);

        void Save(Recipe recipe);

        void Delete(Guid recipeId);

        void Insert(Recipe recipe);

        void Update(Recipe recipe);
    }
}
