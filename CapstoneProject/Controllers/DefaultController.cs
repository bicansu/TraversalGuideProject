﻿using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
