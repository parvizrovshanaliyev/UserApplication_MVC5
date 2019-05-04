using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication2.Models;

namespace UserApplication2.Controllers
{
    public class HomeController : Controller
    {
        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View(UserManagerApp.Users);
        }
    }
}