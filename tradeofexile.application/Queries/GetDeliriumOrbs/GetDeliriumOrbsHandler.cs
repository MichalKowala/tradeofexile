using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;

namespace tradeofexile.application.Queries.GetDeliriumOrbs
{
    public class GetDeliriumOrbsHandler : IRequestHandler<GetDeliriumOrbsQuery, List<ItemDTO>>
    {
        private readonly IItemInteractor _itemInteractor;
        private readonly ICacheProvider _cacheProvider;
        public GetDeliriumOrbsHandler(IItemInteractor itemInteractor, ICacheProvider cacheProvider)
        {
            _itemInteractor = itemInteractor;
            _cacheProvider = cacheProvider;
        }
        public async Task<List<ItemDTO>> Handle(GetDeliriumOrbsQuery request, CancellationToken cancellationToken)
        {
            var result = _cacheProvider.GetFromCache<List<ItemDTO>>(request.CacheKey);
            if (result != null)
                return result.Where(x => x.League == request.LeagueType).ToList();
            else
            {
                CacheDeliriumOrbs(request.CacheKey);
                result = _cacheProvider.GetFromCache<List<ItemDTO>>(request.CacheKey);
                return result.Where(x => x.League == request.LeagueType).ToList();
            }
        }
        private void CacheDeliriumOrbs(string cacheKey)
        {
            var itemsToCache = _itemInteractor.GetDeliriumOrbsToCache();
            _cacheProvider.SetCache<List<ItemDTO>>(cacheKey, itemsToCache);
        }
    }
   
}
