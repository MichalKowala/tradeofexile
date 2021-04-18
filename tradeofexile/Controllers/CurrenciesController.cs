using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Interfaces;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ICurrenciesService _currenciesService;
        private readonly IPoeApiIResponseHandler _blabla;
        public CurrenciesController(ICurrenciesService currenciesService, IPoeApiIResponseHandler blabla)
        {
            _blabla = blabla;
            _currenciesService = currenciesService;
        }
        public IActionResult Index(int page = 1)
        {

            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var currenciesVM = new CurrenciesViewModel();
            currenciesVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var offers = _currenciesService
                .GetCachedCurrencies(nameof(CacheKeys.Currencies), (LeagueType)selectedLeague)
                .Take(currenciesVM.PagingInfo.CurrentPage * currenciesVM.PagingInfo.ItemsPerPage)
                .ToList();
            currenciesVM.ExchangeOffers = offers;
            return View(currenciesVM);
        }
    }
}
