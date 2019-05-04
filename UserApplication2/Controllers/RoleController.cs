using Microsoft.AspNet.Identity;
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
    public class RoleController : Controller
    {
        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleManagerApp RoleManagerApp { get { return HttpContext.GetOwinContext().GetUserManager<RoleManagerApp>(); } }


        // GET: Role
        public ActionResult Index()
        {
            return View(RoleManagerApp.Roles);
        }



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public ActionResult CreateRole(RoleApp role)
        {
            RoleManagerApp.Create(role);

            return RedirectToAction("Index");
        }


        public ActionResult UserRolesManager()
        {
            return View(UserManagerApp.Users);
        }

        [HttpPost]
        public ActionResult UserRolesManager(IEnumerable<string> RoleNames,string userId)
        {
            IEnumerable<String> rolenames = RoleNames ?? new List<string>();

            IEnumerable<string> selectedRoles = rolenames;
            IEnumerable<string> UnselectedRoles = Helper.GetRoles().Select(a => a.Name).Except(rolenames); //secilmemis olan role names goturdum

            //selected role
            foreach (var rolename in selectedRoles.ToList())
            {
                if (!UserManagerApp.IsInRole(userId, rolename))
                {
                    UserManagerApp.AddToRole(userId, rolename);
                }
            }

            ///un selected role
            foreach (var rolename in UnselectedRoles.ToList())
            {
                if (UserManagerApp.IsInRole(userId, rolename))
                {
                    UserManagerApp.RemoveFromRole(userId, rolename);
                }
            }
            //UserApp userdb = UserManagerApp.FindById(userId);

            //foreach (string name in RoleNames)
            //{
            //    if (!UserManagerApp.IsInRole(userId, name))
            //    {
            //        UserManagerApp.AddToRole(userId, name);
            //    }
            //}
            return RedirectToAction("Index");
        }

    }
}