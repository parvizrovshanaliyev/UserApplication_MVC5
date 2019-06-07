namespace UserApplication2.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Security;
    using UserApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UserApplication2.DAL.UserAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UserApplication2.DAL.UserAppDbContext";
        }

       

        protected override void Seed(UserApplication2.DAL.UserAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.



            context.Roles.AddOrUpdate(r => new { r.Name }, new RoleApp {  Name = "admins" });


            context.Users.AddOrUpdate(u => new { u.Email, u.UserName },

                new Models.UserApp
                {
                    
                    Email = "parviz@gmail.com",
                    UserName = "parvizrov",
                    PasswordHash = Crypto.HashPassword("parviz123"),
                    SecurityStamp = Crypto.Hash(DateTime.Now.ToString("yyyyMMddHHmmssfff")),


                });

            context.AspNetUserRoles.Add(new AspNetUserRole
            {
                UserId = "90617813-c34b-4a69-99bb-ab0b22d80b22",
                RoleId = "fcece545-1881-4eb4-b8fb-2987a164df28",
            });

            //context.AspNetRoles
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
