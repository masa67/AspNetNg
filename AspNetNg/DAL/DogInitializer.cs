using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetNg.DAL
{
    public class DogInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<DogContext>
    {
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
        }
    }
}