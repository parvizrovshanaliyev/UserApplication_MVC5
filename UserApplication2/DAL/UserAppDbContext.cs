﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UserApplication2.Models;

namespace UserApplication2.DAL
{
    public class UserAppDbContext : IdentityDbContext<UserApp>
    {
        public UserAppDbContext() : base("UserApp2")
        {

        }

        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new UserAppDbContextInitializer());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public class UserAppDbContextInitializer : DropCreateDatabaseIfModelChanges<UserAppDbContext>
        {
            

            protected override void Seed(UserAppDbContext context)
            {
                UserManagerApp userManager = new UserManagerApp(new UserStore<UserApp>(context));


                ////Step 1 Create the user.
                //var passwordHasher = new PasswordHasher();
                //IdentityUser user = new IdentityUser("Administrator")
                //{
                //    PasswordHash = passwordHasher.HashPassword("Admin12345"),
                //    SecurityStamp = Guid.NewGuid().ToString()
                //};

                ////Step 2 Create and add the new Role.
                //var roleToChoose = new IdentityRole("Admin4");
                //context.Roles.Add(roleToChoose);

                ////Step 3 Create a role for a user
                //var role = new IdentityUserRole
                //{
                //    RoleId = roleToChoose.Id,
                //    UserId = user.Id
                //};

                ////Step 4 Add the role row and add the user to DB)
                //user.Roles.Add(role);
                //context.Users.Add((UserApp)user);

                base.Seed(context);
            }
        }




    }


    
}