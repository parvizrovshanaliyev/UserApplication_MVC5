using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplication2.Models
{
    public class RoleApp : IdentityRole
    {
        public RoleApp():base()
        {
            //AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

        public RoleApp(string roleName) : base(roleName)
        {
        }

        //public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

    }
}