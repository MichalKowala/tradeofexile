using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class WeaponsController : Controller
    {
        private readonly IUniquesService _uniquesService;
        public WeaponsController(IUniquesService uniquesService)
        {
            _uniquesService = uniquesService;
        }
        public IActionResult Index(int page=1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var weaponsVM = new ItemsViewModel();
            weaponsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _uniquesService
                .GetCachedUniques(nameof(CacheKeys.Weapons), (LeagueType)selectedLeague, ItemCategory.Weapons)
                .Take(weaponsVM.PagingInfo.CurrentPage*weaponsVM.PagingInfo.ItemsPerPage)
                .ToList();
            weaponsVM.ItemsToShow = items;
            return View(weaponsVM);
        }
    }
}
