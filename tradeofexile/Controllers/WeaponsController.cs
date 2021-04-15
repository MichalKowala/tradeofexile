﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tradeofexile.application.Utilities;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Controllers
{
    public class WeaponsController : Controller
    {
        private readonly IItemsService _itemModelService;
        public WeaponsController(IItemsService itemModelService)
        {
            _itemModelService = itemModelService;
        }
        public IActionResult Index(int page=1)
        {
            int selectedLeague;
            int.TryParse(HttpContext.Request.Cookies["selectedLeagueId"], out selectedLeague);
            var weaponsVM = new ItemsViewModel();
            weaponsVM.PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 5 };
            var items = _itemModelService
                .GetCachedItems(nameof(CacheKeys.Weapons), (LeagueType)selectedLeague, ItemCategory.Weapons)
                .Take(weaponsVM.PagingInfo.CurrentPage*weaponsVM.PagingInfo.ItemsPerPage)
                .ToList();
            weaponsVM.ItemsToShow = items;
            return View(weaponsVM);
        }
    }
}