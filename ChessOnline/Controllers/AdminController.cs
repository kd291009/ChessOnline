using Microsoft.AspNetCore.Mvc;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using ChessOnline.Data;

namespace ChessOnline.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AdminController : Controller
    {


        private UserManager<UserInfo> userManager;
        private IPasswordHasher<UserInfo> passwordHasher;
        private IPasswordValidator<UserInfo> passwordValidator;
        private IUserValidator<UserInfo> userValidator;


        public AdminController(UserManager<UserInfo> usrMgr, IPasswordHasher<UserInfo> passwordHash, IPasswordValidator<UserInfo> passwordVal, IUserValidator<UserInfo> userVal)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userVal;
        }

        //get id
        public async Task<IActionResult> Edit(string id)
        {
            UserInfo user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string passwordHash)
        {
            UserInfo user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");


                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(passwordHash))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, passwordHash);
                    if(validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, passwordHash);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);

        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }




        public IActionResult Index()
        {
            return View(userManager.Users);
        }




        [AllowAnonymous]
        public ViewResult Create() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                UserInfo userInfo = new UserInfo
                {
                    UserName = user.Name,
                    Email = user.Email
                };
                //CreateAsync(TUSer,string) creates user with given password
                IdentityResult result = await userManager.CreateAsync(userInfo, user.Password);
                //if redirect to Index we get authentification error if user is not admin
                if (result.Succeeded)
                    return RedirectToAction("Index", "HomeChessPLayer");
                else
                {
                    foreach(IdentityError error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        
        
            return View(user);

            
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserInfo user = await userManager.FindByIdAsync(id);
            if (user == null) {
                ModelState.AddModelError("", "User Not Found");
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            UserInfo user = await userManager.FindByIdAsync(id);
            IdentityResult result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                Errors(result);
            return View("Index",userManager.Users);

        }
    }
    
}
