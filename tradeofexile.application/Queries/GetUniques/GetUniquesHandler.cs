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
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Queries.GetUniques
{
    public class GetUniquesHandler : IRequestHandler<GetUniquesQuery, List<ItemDTO>>
    {
        private readonly IItemInteractor _itemInteractor;
        private readonly ICacheProvider _cacheProvider;

        public GetUniquesHandler(IItemInteractor itemInteractor, ICacheProvider cacheProvider)
        {
            _itemInteractor = itemInteractor;
            _cacheProvider = cacheProvider;
        }
        public async Task<List<ItemDTO>> Handle(GetUniquesQuery request, CancellationToken cancellationToken)
        {
            var result = _cacheProvider.GetFromCache<List<ItemDTO>>(request.CacheKey);
            if (result != null)
                return result.Where(x => x.League == request.League).ToList();
            else
            {
                CacheUniques(request.CacheKey, request.Category);
                result = _cacheProvider.GetFromCache<List<ItemDTO>>(request.CacheKey);
                return result.Where(x => x.League == request.League).ToList();
            }
        }
        private void CacheUniques(string cacheKey, ItemCategory category)
        {
            var itemsToCache = _itemInteractor.GetUniquesToCache(category);
            _cacheProvider.SetCache<List<ItemDTO>>(cacheKey, itemsToCache);
        }
    }
}
