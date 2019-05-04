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
                base.Seed(context);
            }
        }




    }


    
}