﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApplication2.DAL;

namespace UserApplication2.Models
{
    public class RoleManagerApp : RoleManager<RoleApp>
    {
        public RoleManagerApp(IRoleStore<RoleApp, string> store) : base(store)
        {
        }

        public static RoleManagerApp Create(IdentityFactoryOptions<RoleManagerApp> identityFactoryOptions,IOwinContext owinContext)
        {

            return new RoleManagerApp(new RoleStore<RoleApp>(owinContext.Get<UserAppDbContext>()));
        }

    }
}