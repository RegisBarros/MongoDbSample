using MongoDbSample.ConsoleApp.Models;
using MongoDbSample.ConsoleApp.Repositories.Interfaces;
using System;
using System.Linq;

namespace MongoDbSample.ConsoleApp
{
    public class Application
    {
        private readonly IRecipeRepository _recipeRepository;

        public Application(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public void Run()
        {
            //AddRecipe();

            //DeleteRecipe();

            //UpdateRecipe();

            //ShowRecipes();

            SearchRecipes();
        }

        public void AddRecipe()
        {
            var cake = new Recipe("Chocolate Cake", "This is chocolate cake", "Chocolate, 4 eggs", "Preheat oven to 350 degrees", "cake.jpg", "cake chocolate", false, 45);
            var pie = new Recipe("Basic Flaky Pie Crust", "Pie Crust", "11/4 cups all-purpose flour, 1/4 teaspoon salt", "Whisk the flour and salt together", "pie.jpg", "pie", false, 80);
            var burger = new Recipe("Best Burger Ever", "These burgers are the best on the grill in the summertime", "lean ground beef", "Preheat a grill for high heat", "burger.jpg", "burgers grill", true, 10);
            var cookies = new Recipe("Big Soft Ginger Cookies", "These are just what they say, big, soft, gingerbread cookies", "all-purpose flour, ginger, white sugar", "Bake for 8 to 10 minutes in the preheat oven", "cookie.jpg", "cookie bake", false, 15);
            var spaghetti  = new Recipe("Spaghetti Italian", "Delicious and not so sweet", "Italian sauce, tomato sauce, package spaghetti", "Mix sauce with hot paste", "spaghetti.jpg", "bolo chocolate", true, 20);

            _recipeRepository.Insert(cake);
            _recipeRepository.Insert(pie);
            _recipeRepository.Insert(burger);
            _recipeRepository.Insert(cookies);
            _recipeRepository.Insert(spaghetti);
        }

        public void DeleteRecipe()
        {
            var recipeId = Guid.Parse("70524320-a59f-4d63-b34d-5b7f71b31ab4");

            _recipeRepository.Delete(recipeId);
        }

        public void UpdateRecipe()
        {
            var recipeId = Guid.Parse("1d79aafc-7866-41c4-85ec-09c79fd2b6bc");

            var recipe = _recipeRepository.GetById(recipeId);

            recipe.ChangeTitle("Cake Chocolate");

            _recipeRepository.Update(recipe);
        }

        public void ShowRecipes()
        {
            var recipes = _recipeRepository.Get();

            foreach (var r in recipes)
            {
                Console.WriteLine($"{r.Title}");
            }

            Console.ReadKey();
        }

        public void SearchRecipes()
        {
            do
            {
                Console.Write("Find a recipe: ");
                var search = Console.ReadLine();

                var recipes = _recipeRepository.Search(search);

                if (recipes != null && recipes.Any())
                {
                    foreach (var r in recipes)
                    {
                        Console.WriteLine($"{r.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("no results");
                }

                Console.ReadKey();
                Console.Clear();

            } while (true);
        }
    }
}
