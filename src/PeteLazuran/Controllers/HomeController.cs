﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeteLazuran.Models;


namespace PeteLazuran.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Projects()
        {
            var starredRepos = Repo.FindRepos();
            return View(starredRepos);
        }
    }
}
