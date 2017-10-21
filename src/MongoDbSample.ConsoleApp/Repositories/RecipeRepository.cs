using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbSample.ConsoleApp.Models;
using MongoDbSample.ConsoleApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDbSample.ConsoleApp.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _context;

        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        public void Delete(Guid recipeId)
        {
            _context.Recipes.DeleteOne(r => r.Id == recipeId);
        }

        public IEnumerable<Recipe> Get()
        {
            return _context.Recipes
                .Find(new BsonDocument())
                .ToList();
        }

        public Recipe GetById(Guid recipeId)
        {
            return _context.Recipes.Find(r => r.Id == recipeId)
                .FirstOrDefault();
        }

        public void Insert(Recipe recipe)
        {
            _context.Recipes.InsertOne(recipe);
        }

        // Insert or Update a document
        public void Save(Recipe recipe)
        {
            var options = new UpdateOptions
            {
                IsUpsert = true
            };

            _context.Recipes.ReplaceOne(r => r.Id == recipe.Id, recipe, options);
        }

        public IEnumerable<Recipe> Search(string criteria)
        {
            return _context.Recipes.AsQueryable()
                 .Where(r => r.Title.Contains(criteria) || r.Tags.Contains(criteria))
                .ToList();
        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.ReplaceOne(r => r.Id == recipe.Id, recipe);
        }
    }
}
