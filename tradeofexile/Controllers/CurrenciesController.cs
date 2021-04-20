using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Queries.GetCurrencies;
using tradeofexile.application.Utilities;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly IMediator _mediator; 
        public CurrenciesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var currenciesVM = new CurrenciesViewModel();
            currenciesVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = await _mediator.Send(new GetCurrenciesQuery((LeagueType)selectedLeague, nameof(CacheKeys.Currencies)));
            currenciesVM.ExchangeOffers = items;
            return View(currenciesVM);
        }
    }
}
