using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;
using tradeofexile.application.Interfaces;
using MediatR;
using System.Threading.Tasks;
using tradeofexile.application.Queries.GetDeliriumOrbs;

namespace tradeofexile.Controllers
{
    public class DeliriumOrbsController : Controller
    {
        private readonly IMediator _mediator;
        public DeliriumOrbsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var deliriumOrbsVM = new ItemsViewModel();
            deliriumOrbsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            deliriumOrbsVM.ItemsToShow = await _mediator.Send(new GetDeliriumOrbsQuery((LeagueType)selectedLeague, nameof(CacheKeys.DeliriumOrbs)));
            return View(deliriumOrbsVM);
        }
    }
}
