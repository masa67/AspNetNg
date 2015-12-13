namespace AspNetNg.Migrations
{
    using Models;
    using DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogContext context)
        {
            var dogs = new List<Dog>
            {
                new Dog { Name = "Viki", Breed = "Irish Setter" },
                new Dog { Name = "Timi", Breed = "Cavalier King Charles Spaniel" },
                new Dog { Name = "Otto", Breed = "Boxer" }
            };

            dogs.ForEach(d => context.Dogs.Add(d));
            context.SaveChanges();

            DAL.GenericRepository repo = new GenericRepository(context);
        }
    }
}
