using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tradeofexile.application.Queries.GetUniques;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class FlasksController : Controller
    {
        private readonly IMediator _mediator;
        public FlasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var flasksVM = new ItemsViewModel();
            flasksVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            flasksVM.ItemsToShow = await _mediator.Send(new GetUniquesQuery((LeagueType)selectedLeague, ItemCategory.Flasks, nameof(CacheKeys.Flasks)));
            return View(flasksVM);
        }
    }
}
