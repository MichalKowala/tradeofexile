using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tradeofexile.application.Queries.GetUniques;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class JewelController : Controller
    {
        private readonly IMediator _mediator;
        public JewelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var jewelVM = new ItemsViewModel();
            jewelVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            jewelVM.ItemsToShow = await _mediator.Send(new GetUniquesQuery((LeagueType)selectedLeague, ItemCategory.Jewels, nameof(CacheKeys.Jewels)));
            return View(jewelVM);
        }
    }
}
