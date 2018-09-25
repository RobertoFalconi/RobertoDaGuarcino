﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RobertoDaGuarcino.Models;

namespace RobertoDaGuarcino.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "A little carousel about my works";

            return View();
        }

        public IActionResult MyProjects()
        {
            ViewData["Message"] = "Something about my projects";

            return View();
        }

        public IActionResult MyContacts()
        {
            ViewData["Message"] = "Get in touch with Roberto";

            return View();
        }

        public IActionResult MyGames()
        {

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
