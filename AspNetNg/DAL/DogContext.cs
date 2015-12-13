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

        public DbSet<Grievance> Grievance { get; set; }
        public DbSet<GrievanceStep> GrievanceStep { get; set; }
        public DbSet<ActionDirectory> ActionDirectory { get; set; }
        public DbSet<Filesystem> Filesystem { get; set; }
        public DbSet<AspNetNg.Models.Action> Action { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

