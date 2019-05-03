using Microsoft.AspNet.Identity;
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
    public class UserManagerApp : UserManager<UserApp>
    {
        public UserManagerApp(IUserStore<UserApp> store) : base(store)
        {
        }

        public static UserManagerApp Create(IdentityFactoryOptions<UserManagerApp> identityFactoryOptions, IOwinContext owinContext)
        {
            UserAppDbContext context = owinContext.Get<UserAppDbContext>();
            UserManagerApp user = new UserManagerApp(new UserStore<UserApp>(context));


            PasswordValidator pass = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false
            };
            //pass.RequireNonLetterOrDigit = true; //passwordde her reqemden basqa simvol olmasi ucun

            UserValidator<UserApp> userValidator = new UserValidator<UserApp>(user)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true
            };

            user.PasswordValidator = pass;
            user.UserValidator = userValidator;
            return user;
        }
    }
}