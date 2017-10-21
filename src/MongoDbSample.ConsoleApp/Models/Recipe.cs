using System;

namespace MongoDbSample.ConsoleApp.Models
{
    public class Recipe
    {
        public Recipe(string title, string description, string ingredients, string directions, string photo, string tags, bool favorite, int prep)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Directions = directions;
            Photo = photo;
            Tags = tags;
            Favorite = favorite;
            Prep = prep;
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Ingredients { get; private set; }

        public string Directions { get; private set; }

        public string Photo { get; private set; }

        public string Tags { get; private set; }

        public bool Favorite { get; private set; }

        public int Prep { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }
    }
}
