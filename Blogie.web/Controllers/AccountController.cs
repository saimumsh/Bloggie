using Blogie.core.UserInfo;
using Blogie.data.Repositoty;
using Blogie.web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogie.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserData> signInManager;
        private readonly IRepository<UserData> _userData;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AccountController(SignInManager<UserData> signInManager, IWebHostEnvironment webHostEnvironment,IRepository<UserData> userData)
        {
            this.signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _userData = userData;

        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogIn login)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password,login.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("","Invalid LogIn Attemp !");
            return View(login);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                UserData user = new()
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    PasswordHash = register.Password
                };

                _userData.Add(user);
                return RedirectToAction("LogIn", "Account");


            }
            return View(register);
        }
    }
}
