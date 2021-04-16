using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class FlasksController : Controller
    {
        private readonly IUniquesService _uniquesService;
        public FlasksController(IUniquesService uniquesService)
        {
            _uniquesService = uniquesService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var flasksVM = new ItemsViewModel();
            flasksVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _uniquesService
                .GetCachedUniques(nameof(CacheKeys.Flasks), (LeagueType)selectedLeague, ItemCategory.Flasks)
                .Take(flasksVM.PagingInfo.CurrentPage * flasksVM.PagingInfo.ItemsPerPage)
                .ToList();
            flasksVM.ItemsToShow = items;
            return View(flasksVM);
        }
    }
}
