﻿using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace INTEX2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICrashRepository repo;
        public HomeController(ICrashRepository temp)
        {
            repo = temp;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Tableau()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Temp(int pageNum)
        {
            int pageSize = 10;

            var temp = new CrashesViewModel
            {
                Crashes = repo.Crashes.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = (repo.Crashes.Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(temp);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
