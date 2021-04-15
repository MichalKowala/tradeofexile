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
        private readonly IItemsService _itemModelService;
        public FlasksController(IItemsService itemModelService)
        {
            _itemModelService = itemModelService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var flasksVM = new ItemsViewModel();
            flasksVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _itemModelService
                .GetCachedItems(nameof(CacheKeys.Flasks), (LeagueType)selectedLeague, ItemCategory.Flasks)
                .Take(flasksVM.PagingInfo.CurrentPage * flasksVM.PagingInfo.ItemsPerPage)
                .ToList();
            flasksVM.ItemsToShow = items;
            return View(flasksVM);
        }
    }
}
