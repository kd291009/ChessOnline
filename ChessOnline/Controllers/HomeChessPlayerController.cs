using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ChessOnline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChessOnline.Controllers
{
    public class HomeChessPlayerController : Controller
    {
        //dependency injection
        private UserManager<UserInfo> userManager;
        public HomeChessPlayerController(UserManager<UserInfo> userMgr)
        {
            userManager = userMgr;
        }
        /* //Get /Account/Login
         * Because of Identity library
         * Returns to HomeChessPlayer route when authentificated
         */
        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserInfo user = await userManager.GetUserAsync(HttpContext.User);
            string message = "Hello " + user.UserName + " !";
            return View((object)message);
        }

        /*// Get /HomeChess/
        public string Index()
        {
            return "This is the default action";
        }*/

        // Get /HomeChessPlayer/Welcome
        public IActionResult Welcome(string name, int elo = 600, int ID = 1)
        {
            ViewData["Name"] = "Hello " + name;
            ViewData["Ranking"] = elo;
            ViewData["ID"] = ID;
            return View();
        }
    }
}
