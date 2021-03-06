﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Queries.GetUniques;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class WeaponsController : Controller
    {
        private readonly IMediator _mediator;
        public WeaponsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var weaponsVM = new ItemsViewModel();
            weaponsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            weaponsVM.ItemsToShow = await _mediator.Send(new GetUniquesQuery((LeagueType)selectedLeague, ItemCategory.Weapons, nameof(CacheKeys.Weapons)));
            return View(weaponsVM);
        }
    }
}
