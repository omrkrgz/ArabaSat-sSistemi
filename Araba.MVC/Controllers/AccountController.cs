using Araba.BLL.Account;
using Araba.Entity.IdentityModels;
using Araba.Entity.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Araba.MVC.Controllers
{
    public class AccountController : Controller
    {
        public Task SiteSettings { get; private set; }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userManager = MemberShipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Name);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlı!");
                return View(model);
            }
            var user = new ApplicationUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                Birthday = model.DogumTarihi



            };
            var sonuc = userManager.Create(user, model.Password);
            if (sonuc.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
                userManager.AddToRole(user.Id, "User");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
                return View(model);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userManager = MemberShipTools.NewUserManager();
            var user = await userManager.FindAsync(model.Username, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunamadı");
                return View(model);
            }
            var authManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authManager.SignIn(new AuthenticationProperties()
            {
                IsPersistent = model.RememberMe
            }, userIdentity);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Profile()
        {
            var userManager = MemberShipTools.NewUserManager();
            var id = HttpContext.User.Identity.GetUserId();
            var user = userManager.FindById(id);

            ProfileViewModel model = new ProfileViewModel()
            {
            
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
             
            };

            return View(model);
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userStore = MemberShipTools.NewUserStore();
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = userManager.FindById(HttpContext.User.Identity.GetUserId());
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            
          


            await userStore.UpdateAsync(user);
            await userStore.Context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }
       
    }
}