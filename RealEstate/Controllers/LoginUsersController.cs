using Microsoft.AspNetCore.Mvc;
using Bl;
using Microsoft.AspNetCore.Identity;
using RealEstate.Models;

namespace RealEstate.Controllers
{

    public class LoginUsersController : Controller
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly SignInManager<ApplicationUser> SignInManager;
        public LoginUsersController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signin)
        {
            userManager = user;
            SignInManager = signin;
        }

        public IActionResult AccessDenied()
        {
            return View();

        }


        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }




        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/LoginUsers/Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);

            //if (userModel.ReturnUrl == "/")
            //    userModel.ReturnUrl = "~/";


            //if (string.IsNullOrEmpty(userModel.ReturnUrl))
            //    userModel.ReturnUrl = "~/";


            var user = await userManager.FindByEmailAsync(userModel.Email);


            if (user == null)
            {
                ModelState.AddModelError("Email", "لا يوجد مستخدم بهذا الايميل");
                return View(userModel);

            }


            var result = await SignInManager.PasswordSignInAsync(userModel.Email, userModel.Password, true, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "من فضلك ادخل كلمة المرور صحيحة");
                return View(userModel);
            }
            else
                return Redirect("/Admin/Home/Index");

            


        }
    }
}
