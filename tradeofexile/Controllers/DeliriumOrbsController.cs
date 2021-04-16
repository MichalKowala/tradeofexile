using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class DeliriumOrbsController : Controller
    {
        private readonly IDeliriumOrbsService _deliriumOrbsService;
        public DeliriumOrbsController(IDeliriumOrbsService delirumOrbsService)
        {
            _deliriumOrbsService = delirumOrbsService;
        }
        public IActionResult Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var deliriumOrbsVM = new ItemsViewModel();
            deliriumOrbsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _deliriumOrbsService
                .GetCachedDeliriumOrbs(nameof(CacheKeys.DeliriumOrbs), (LeagueType)selectedLeague)
                .Take(deliriumOrbsVM.PagingInfo.CurrentPage * deliriumOrbsVM.PagingInfo.ItemsPerPage)
                .ToList();
            deliriumOrbsVM.ItemsToShow = items;
            return View(deliriumOrbsVM);
        }
    }
}
