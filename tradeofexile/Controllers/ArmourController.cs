using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class ArmourController : Controller
    {
        private readonly IItemsService _itemModelService;
        private readonly IPoeApiIResponseHandler _api;
        public ArmourController(IItemsService itemModelService)
        {
            _itemModelService = itemModelService;
        }
        public IActionResult Index(int page = 1)
        {
            for (int i = 0; i < 15; i++)
            {
                _api.GetAndProcessPoeApiResponse();
            }
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var armourVM = new ItemsViewModel();
            armourVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _itemModelService
                .GetCachedItems(nameof(CacheKeys.Armour), (LeagueType)selectedLeague, ItemCategory.Armour)
                .Take(armourVM.PagingInfo.CurrentPage * armourVM.PagingInfo.ItemsPerPage)
                .ToList();
            armourVM.ItemsToShow = items;
            return View(armourVM);
        }
    }
}
