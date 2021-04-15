using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Interfaces;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemInteractor _itemInteractor;
        private readonly ICacheProvider _cacheProvider;
        private readonly IMapper _mapper;
        public ItemsService(IItemInteractor itemInteractor, ICacheProvider cacheProvider, IMapper mapper)
        {
            _itemInteractor = itemInteractor;
            _cacheProvider = cacheProvider;
            _mapper = mapper;
        }

        public List<ItemModel> GetCachedItems(string cacheKey, LeagueType league, ItemCategory category)
        {
            var result = _cacheProvider.GetFromCache<List<ItemModel>>(cacheKey);
            if (result != null)
                return result.Where(x => x.League == league).ToList();
            else
            {
                CacheItems(cacheKey, category);
                result = _cacheProvider.GetFromCache<List<ItemModel>>(cacheKey);
                return result.Where(x => x.League == league).ToList();
            }
        }


        public void CacheItems(string cacheKey, ItemCategory category)
        {
            var itemsToCache = GetItemsToCache(category);
            _cacheProvider.SetCache<List<ItemModel>>(cacheKey, itemsToCache);
        }

        private List<ItemModel> GetItemsToCache(ItemCategory category)
        {
            var unprocessed = _itemInteractor.GetPricedUniquesByItemCategory(category);
            var leagueGroupings = unprocessed.GroupBy(x => x.League);
            List<ItemModel> cacheValue = new List<ItemModel>();
            foreach (var lG in leagueGroupings)
            {
                var nameLeagueGroupings = lG.GroupBy(x => x.Name);
                foreach (var nLG in nameLeagueGroupings)
                {
                    cacheValue.Add(ProcessNameLeagueGrouping(nLG));
                }
            }
            return cacheValue;
        }

        private ItemModel ProcessNameLeagueGrouping(IGrouping<string, Item> groupings)
        {
            ItemModel result = _mapper.Map<Item,ItemModel>(groupings.First());
            result.Occurances = groupings.Count();
            var currencyGroupings = groupings.GroupBy(x => x.Price.CurrencyType).OrderByDescending(x => x.Count());
            CurrencyType primaryCurrency = currencyGroupings.First().Key;
            foreach (var cG in currencyGroupings)
            {
                List<Price> prices = new List<Price>();
                foreach (Item i in cG)
                {
                    prices.Add(i.Price);
                }
                CalculatePriceRelatedProperties(result, primaryCurrency, prices);
            }
            return result;
        }

        private void CalculatePriceRelatedProperties(ItemModel model, CurrencyType primaryCurrency, List<Price> prices)
        {
            var averaged = _mapper.Map<Price,PriceModel>(_itemInteractor.CalculateAveragePrice(prices));
            if (averaged.CurrencyType == primaryCurrency)
            {
                model.Price = averaged;
                var oldPrices = prices.Where(x => DateTime.Now.AddDays(-7) > x.DateCreated).ToList();
                if (oldPrices.Count != 0)
                {
                    var averagedOld = _itemInteractor.CalculateAveragePrice(oldPrices);
                    model.SevenDaysChange = _itemInteractor.CalculateChange(averagedOld.Ammount, model.Price.Ammount);
                }
            }
            else
                model.OtherCurrencyPrices.Add(averaged);
        }
       
    }
}

