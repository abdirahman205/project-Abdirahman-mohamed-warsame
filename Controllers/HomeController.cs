﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project_asp.net.Controllers
{
    public class HomeController : Controller
    {
    //    [Authorize]
        public IActionResult Index()
        {
            return View();
        }

         
    }
}
