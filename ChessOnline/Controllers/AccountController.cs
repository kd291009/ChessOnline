using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ChessOnline.Models;
using System.Threading.Tasks;

namespace ChessOnline.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<UserInfo> userManager;
        private SignInManager<UserInfo> signInManager;

        public AccountController(UserManager<UserInfo> userMgr, SignInManager<UserInfo> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login()
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserInfo user = await userManager.FindByEmailAsync(login.Email);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    return Redirect(login.ReturnUrl ?? "/");



                }
                ModelState.AddModelError(nameof(login.Email),"Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
