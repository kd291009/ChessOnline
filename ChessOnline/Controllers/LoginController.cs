﻿using Microsoft.AspNetCore.Mvc;

namespace ChessOnline.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
