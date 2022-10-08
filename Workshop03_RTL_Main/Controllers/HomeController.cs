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

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _advertiserManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _advertiserManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View(_db);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add() 
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public  IActionResult Add(Advertisement advertisement)
        {
            advertisement.OwnerId =  _advertiserManager.GetUserId(this.User);
            var insidedb = _db.Advertisements.FirstOrDefault(a => a.Name == advertisement.Name );
            if (insidedb == null)
            {
                _db.Advertisements.Add(advertisement);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult Apply(string ad) 
        {
            var ads = _db.Advertisements.FirstOrDefault(t => t.Id == ad);
            Advertiser adv = _db.Advertisers.FirstOrDefault(t => t.Id == _advertiserManager.GetUserId(this.User));
            var isAlreadyApplied = _db.Subscribers.Where(x=>x.AdId == ads.Id && x.SubId == adv.Id).FirstOrDefault();
            if (isAlreadyApplied == null)
            {
                ads.NumberOfSubscribers++;
                var subscriber = new Subscribers() { AdId = ads.Id, SubId = adv.Id };
                _db.Subscribers.Add(subscriber);
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
