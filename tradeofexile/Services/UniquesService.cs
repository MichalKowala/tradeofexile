using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;
using tradeofexile.Interfaces;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Services
{
    public class UniquesService : IUniquesService
    {
        private readonly IItemInteractor _itemInteractor;
        private readonly ICacheProvider _cacheProvider;
        public UniquesService(IItemInteractor itemInteractor, ICacheProvider cacheProvider, IMapper mapper)
        {
            _itemInteractor = itemInteractor;
            _cacheProvider = cacheProvider;
        }

        public List<ItemDTO> GetCachedUniques(string cacheKey, LeagueType league, ItemCategory category)
        {
            var result = _cacheProvider.GetFromCache<List<ItemDTO>>(cacheKey);
            if (result != null)
                return result.Where(x => x.League == league).ToList();
            else
            {
                CacheUniques(cacheKey, category);
                result = _cacheProvider.GetFromCache<List<ItemDTO>>(cacheKey);
                return result.Where(x => x.League == league).ToList();
            }
        }


        public void CacheUniques(string cacheKey, ItemCategory category)
        {
            var itemsToCache = _itemInteractor.GetUniquesToCache(category);
            _cacheProvider.SetCache<List<ItemDTO>>(cacheKey, itemsToCache);
        }
    }
}

