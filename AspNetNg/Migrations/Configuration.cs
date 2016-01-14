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
            User a = new User() { name = "a" };
            User b = new User() { name = "b" };
            User c = new User() { name = "c" };
            User d = new User() { name = "d" };

            Group g1 = new Group() { name = "g1" };
            Group g2 = new Group() { name = "g2" };
            Group g3 = new Group() { name = "g3" };

            a.groups = new List<Group>();
            a.groups.Add(g1);
            a.groups.Add(g2);

            b.groups = new List<Group>();
            b.groups.Add(g1);

            c.groups = new List<Group>();
            c.groups.Add(g2);

            d.groups = new List<Group>();
            d.groups.Add(g3);

            List<User> users = new List<User> { a, b, c, d };
            List<Group> groups = new List<Group> { g1, g2, g3 };

            users.ForEach(u => context.User.Add(u));
            groups.ForEach(g => context.Group.Add(g));
            context.SaveChanges();

            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            List<string> names = context.User
                .Where(u => u.name == "a")
                .SelectMany(u => u.groups)
                .SelectMany(g => g.users)
                .Distinct()
                .Select(u => u.name)
                .ToList();
        }
    }
}
