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
        private readonly IUniquesService _uniquesService;
        public ArmourController(IUniquesService uniquesService)
        {
            _uniquesService = uniquesService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var armourVM = new ItemsViewModel();
            armourVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _uniquesService
                .GetCachedUniques(nameof(CacheKeys.Armour), (LeagueType)selectedLeague, ItemCategory.Armour)
                .Take(armourVM.PagingInfo.CurrentPage * armourVM.PagingInfo.ItemsPerPage)
                .ToList();
            armourVM.ItemsToShow = items;
            return View(armourVM);
        }
    }
}
