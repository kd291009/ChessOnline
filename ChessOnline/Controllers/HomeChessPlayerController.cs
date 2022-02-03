using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ChessOnline.Controllers
{
    public class HomeChessPlayerController : Controller
    {
       /* //Get /HomeChessPlayer/
        */

        public IActionResult Index()
        {
            return View();
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
