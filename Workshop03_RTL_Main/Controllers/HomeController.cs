using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Workshop03_RTL_Main.Data;
using Workshop03_RTL_Main.Models;

namespace Workshop03_RTL_Main.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<Advertiser> _advertiserManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(UserManager<Advertiser> advertiserManager, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _advertiserManager = advertiserManager;
            _roleManager = roleManager;
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Advertisements);
        }
        [Authorize]
        public IActionResult Add() 
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public  IActionResult Add(Advertisement advertisement)
        {
            advertisement.Id =  _advertiserManager.GetUserId(this.User);
            var insidedb = _db.Advertisements.FirstOrDefault(a => a.Name == advertisement.Name );
            if (insidedb == null)
            {
                _db.Advertisements.Add(advertisement);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
