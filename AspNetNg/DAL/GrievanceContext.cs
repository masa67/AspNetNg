using AspNetNg.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetNg.DAL
{
    public class GrievanceContext : DbContext
    {
        public GrievanceContext() : base("GrievanceContext")
        {
        }

        public DbSet<Grievance> Grievance { get; set; }
        public DbSet<GrievanceStep> GrievanceStep { get; set; }
        public DbSet<ActionDirectory> ActionDirectory { get; set; }
        public DbSet<Filesystem> Filesystem { get; set; }
        public DbSet<AspNetNg.Models.Action> Action { get; set; }

        public DbSet<MyOrderModel> MyOrderModel { get; set; }
        public DbSet<MyOrderDetailModel> MyOrderDetailModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

