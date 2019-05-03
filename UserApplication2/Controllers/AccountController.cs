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

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(UserApp user, string Password)
        //{
        //    UserApp userdb = await UserManagerApp.FindByIdAsync(user.Id);

        //    userdb.UserName = user.UserName;
        //    userdb.Email = user.Email;

        //    userdb.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(Password);

        //    IdentityResult results = await UserManagerApp.UpdateAsync(userdb);

        //    if (results.Succeeded)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    results.Errors.ToList().ForEach(x => ModelState.AddModelError("", x));
        //    return View(user);
        //}

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserApp user, string Password)
        {
            if (!ModelState.IsValid) return View(user);

            UserApp userdb = await UserManagerApp.FindByIdAsync(user.Id);
            if (userdb == null) return HttpNotFound();

            if (string.IsNullOrEmpty(user.Email))
            {
                ModelState.AddModelError("Email", "Email not null");
                return View(user);
            }

            if (UserManagerApp.Users.Any(u => u.Email == user.Email && u.Id != user.Id))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View(user);
            }

            if (string.IsNullOrEmpty(user.UserName))
            {
                ModelState.AddModelError("UserName", "UserName not null");
                return View(user);
            }

            if (UserManagerApp.Users.Any(u => u.UserName == user.UserName && u.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName is already taken");
                return View(user);
            }

            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("Password", "Password not null");
                return View(user);
            }
            userdb.UserName = user.UserName;
            userdb.Email = user.Email;
            userdb.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(Password);

            IdentityResult resulte = await UserManagerApp.UpdateAsync(userdb);

            if (resulte.Succeeded) { return RedirectToAction("Index"); }

            resulte.Errors.ToList().ForEach(e => ModelState.AddModelError("Password", e));
            return View(user);


        }

        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound("Id gelmir");
            UserApp userdb = await UserManagerApp.FindByIdAsync(id);
            if (userdb == null) return HttpNotFound("bele bir user yoxdu");
            IdentityResult result = await UserManagerApp.DeleteAsync(userdb);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}