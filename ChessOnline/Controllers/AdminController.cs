using Microsoft.AspNetCore.Mvc;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ChessOnline.Data;

namespace ChessOnline.Controllers
{
    public class AdminController : Controller
    {


        private UserManager<UserInfo> userManager;
        private IPasswordHasher<UserInfo> passwordHasher;


        public AdminController(UserManager<UserInfo> usrMgr, IPasswordHasher<UserInfo> passwordHash)
        {
            this.userManager = usrMgr;
            this.passwordHasher = passwordHash;
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
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            UserInfo user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
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

        public ViewResult Create() => View();
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
                if (result.Succeeded)
                    return RedirectToAction("Index");
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
