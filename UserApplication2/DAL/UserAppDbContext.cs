using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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


    }
}