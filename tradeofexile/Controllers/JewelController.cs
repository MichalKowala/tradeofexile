using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class JewelController : Controller
    {
        private readonly IItemsService _itemModelService;
        public JewelController(IItemsService itemModelService)
        {
            _itemModelService = itemModelService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var jewelVM = new ItemsViewModel();
            jewelVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _itemModelService
                .GetCachedItems(nameof(CacheKeys.Jewels), (LeagueType)selectedLeague, ItemCategory.Jewels)
                .Take(jewelVM.PagingInfo.CurrentPage * jewelVM.PagingInfo.ItemsPerPage)
                .ToList();
            jewelVM.ItemsToShow = items;
            return View(jewelVM);
        }
    }
}
