using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Interfaces;
using tradeofexile.models;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
            
        [HttpPost]
        public IActionResult ChangeSelectedLeague(int selectedLeague)
        {
            CookieOptions leagueCookieOptions = new CookieOptions();
            leagueCookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("selectedLeagueId", selectedLeague.ToString(), leagueCookieOptions);
            string selectedLeagueTxt = Enum.GetName(typeof(LeagueType), selectedLeague);
            HttpContext.Response.Cookies.Append("selectedLeagueText", selectedLeagueTxt, leagueCookieOptions);
             return Redirect(HttpContext.Request.Headers["Referer"]);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
