using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using UserApplication2.DAL;
using UserApplication2.Models;

[assembly: OwinStartup(typeof(UserApplication2.App_Start.OwinStartup))]

namespace UserApplication2.App_Start
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<UserAppDbContext>(() => new UserAppDbContext());

            app.CreatePerOwinContext<UserManagerApp>(UserManagerApp.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.CreatePerOwinContext<RoleManagerApp>(RoleManagerApp.Create);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
