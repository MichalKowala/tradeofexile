using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;
using MediatR;
using tradeofexile.application.Queries.GetUniques;
using System.Threading.Tasks;

namespace tradeofexile.Controllers
{
    public class MapsController : Controller
    {
        private readonly IMediator _mediator;
        public MapsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var mapsVM = new ItemsViewModel();
            mapsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            mapsVM.ItemsToShow = await _mediator.Send(new GetUniquesQuery((LeagueType)selectedLeague, ItemCategory.Maps, nameof(CacheKeys.Maps)));
            return View(mapsVM);
        }
    }
}
