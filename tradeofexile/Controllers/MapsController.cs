using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;
using tradeofexile.application.Interfaces;

namespace tradeofexile.Controllers
{
    public class MapsController : Controller
    {
        private readonly IUniquesService _uniquesService;
        public MapsController(IUniquesService uniquesService)
        {
            _uniquesService = uniquesService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var mapsVM = new ItemsViewModel();
            mapsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _uniquesService
                .GetCachedUniques(nameof(CacheKeys.Maps), (LeagueType)selectedLeague, ItemCategory.Maps)
                .Take(mapsVM.PagingInfo.CurrentPage * mapsVM.PagingInfo.ItemsPerPage)
                .ToList();
            mapsVM.ItemsToShow = items;
            return View(mapsVM);
        }
    }
}
