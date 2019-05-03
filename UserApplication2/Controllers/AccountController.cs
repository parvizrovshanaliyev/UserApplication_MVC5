using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserApplication2.Models;

namespace UserApplication2.Controllers
{
    public class AccountController : Controller
    {
        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }
        // GET: Account
        public ActionResult Index()
        {
            return View(UserManagerApp.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserApp userI,string Password)
        {
            if (!ModelState.IsValid) return View(userI);
            if(UserManagerApp.Users.Any(user=>user.Email == userI.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View(userI);
            }

            if (UserManagerApp.Users.Any(user => user.UserName == userI.UserName))
            {
                ModelState.AddModelError("UserName", "UserName is already taken");
                return View(userI);
            }
            UserApp userdb = new UserApp()
            {
                UserName = userI.UserName,
                Email = userI.Email
            };

            IdentityResult result = await UserManagerApp.CreateAsync(userdb, Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError(" ", item);

                }
                return View(userI);

            }

        }



        public async Task< ActionResult> Edit(string id)
        {
            if (id == null) return HttpNotFound("Id not null!!!");

            UserApp user =await UserManagerApp.FindByIdAsync(id);

            if (user == null) return HttpNotFound("sistemde bele bir istifadeci yoxdur");


            return View(user);

        }


        //[HttpPost,ValidateAntiForgeryToken]

        //public async Task<ActionResult> Edit(UserApp user,string Password)
        //{

        //}

        
    }
}