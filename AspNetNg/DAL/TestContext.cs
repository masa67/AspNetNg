using AspNetNg.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetNg.DAL
{
    public class TestContext : DbContext
    {
        public TestContext() : base("TestContext")
        {
        }

        public DbSet<MyOrderModel> MyOrderModel { get; set; }
        public DbSet<MyOrderDetailModel> MyOrderDetailModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

