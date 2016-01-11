using AspNetNg.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetNg.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class DogContext : IdentityDbContext<ApplicationUser>
    {
        public DogContext() : base("DogContext")
        {
        }

        public static DogContext Create()
        {
            return new DogContext();
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<RootObject> RootObjects { get; set; }
        public DbSet<AObject> AObjects { get; set; }
        public DbSet<BObject> BObjects { get; set; }
        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

