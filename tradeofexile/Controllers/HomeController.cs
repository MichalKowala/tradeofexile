using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.models;

namespace tradeofexile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemInteractor _itemInteractor;
        public HomeController(ILogger<HomeController> logger, IItemInteractor itemInteractor)
        {
            _logger = logger;
            _itemInteractor = itemInteractor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Starcraft()
        {
            _itemInteractor.GetPricedUniquesByItemCategory(models.Items.ItemCategory.Jewels);
            throw new NotImplementedException();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
