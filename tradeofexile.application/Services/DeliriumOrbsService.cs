using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using tradeofexile.application.Abstraction;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Services
{
    public class DeliriumOrbsService : IDeliriumOrbsService
    {
        private readonly IItemInteractor _itemInteractor;
        private readonly ICacheProvider _cacheProvider;
        public DeliriumOrbsService(IItemInteractor itemInteractor, ICacheProvider cacheProvider, IMapper mapper)
        {
            _itemInteractor = itemInteractor;
            _cacheProvider = cacheProvider;
        }

        public List<ItemDTO> GetCachedDeliriumOrbs(string cacheKey, LeagueType league)
        {
            var result = _cacheProvider.GetFromCache<List<ItemDTO>>(cacheKey);
            if (result != null)
                return result.Where(x => x.League == league).ToList();
            else
            {
                CacheDeliriumOrbs(cacheKey);
                result = _cacheProvider.GetFromCache<List<ItemDTO>>(cacheKey);
                return result.Where(x => x.League == league).ToList();
            }
        }


        public void CacheDeliriumOrbs(string cacheKey)
        {
            var itemsToCache = _itemInteractor.GetDeliriumOrbsToCache();
            _cacheProvider.SetCache<List<ItemDTO>>(cacheKey, itemsToCache);
        }
    }
}

