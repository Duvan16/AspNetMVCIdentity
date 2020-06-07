namespace AspNetMVCIdentity.Migrations
{
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            var Password1 = new PasswordHasher();

            if (!context.Users.Any(u => u.UserName == "prueba1@prueba.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "prueba1@prueba.com", Email = "prueba1@prueba.com", PasswordHash = Password1.HashPassword("123456Aa") };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }


            //////Editor/////

            if (!context.Roles.Any(r => r.Name == "Editor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Editor" };

                manager.Create(role);
            }

            var Password2 = new PasswordHasher();

            if (!context.Users.Any(u => u.UserName == "prueba2@prueba.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "prueba2@prueba.com", Email = "prueba2@prueba.com", PasswordHash = Password2.HashPassword("123456Aa") };

                manager.Create(user);
                manager.AddToRole(user.Id, "Editor");
            }


            ///Usuarios////////

            if (!context.Roles.Any(r => r.Name == "Usuarios"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Usuarios" };

                manager.Create(role);
            }

            var Password3 = new PasswordHasher();

            if (!context.Users.Any(u => u.UserName == "prueba3@prueba.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "prueba3@prueba.com", Email = "prueba3@prueba.com", PasswordHash = Password3.HashPassword("123456Aa") };

                manager.Create(user);
                manager.AddToRole(user.Id, "Usuarios");
            }
        }
    }
}
;