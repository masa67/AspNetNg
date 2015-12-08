using AspNetNg.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetNg.DAL
{
    public class DogContext : DbContext
    {
        public DogContext() : base("DogContext")
        {
        }

        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

