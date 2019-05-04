using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApplication2.Models;

namespace UserApplication2
{
    public static class Helper
    {
        public static string GetUserName(string id)
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<UserManagerApp>().FindById(id).UserName;
        }


        public static IEnumerable<RoleApp> GetRoles()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<RoleManagerApp>().Roles;
        }
    }
}