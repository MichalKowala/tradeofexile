using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Controllers
{
    public class WeaponsController : Controller
    {
        private readonly IItemsService _itemModelService;
        private readonly IGamepediaResponseHandler _test;
        public WeaponsController(IItemsService itemModelService, IGamepediaResponseHandler test)
        {
            _itemModelService = itemModelService;
            _test = test;

        }
        public IActionResult Index()
        {
            //_test.UpdateUniqueNames();
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var testu = _itemModelService.GetCachedItems(nameof(CacheKeys.Weapons), (LeagueType)selectedLeague, ItemCategory.Weapons);
            return View(testu);
        }
    }
}
