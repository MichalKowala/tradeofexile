using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;

namespace tradeofexile.application.Queries.GetCurrencies
{
    public class GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, List<ExchangeOfferDTO>>
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly IExchangeOffersInteractor _exchangeOffersInteractor;
        public GetCurrenciesHandler(ICacheProvider cacheProvider, IExchangeOffersInteractor exchangeOffersInteractor)
        {
            _cacheProvider = cacheProvider;
            _exchangeOffersInteractor = exchangeOffersInteractor;
        }
        public async Task<List<ExchangeOfferDTO>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var result =  _cacheProvider.GetFromCache<List<ExchangeOfferDTO>>(request.CacheKey);
            if (result != null)
                return result.Where(x => x.League == request.League).ToList();
            else
            {
                CacheCurrencies(request.CacheKey);
                result = _cacheProvider.GetFromCache<List<ExchangeOfferDTO>>(request.CacheKey);
                return result.Where(x => x.League == request.League).ToList();
            }
        }
        private void CacheCurrencies(string cacheKey)
        {
            var offersToCache = _exchangeOffersInteractor.GetOffersToCache();
            _cacheProvider.SetCache<List<ExchangeOfferDTO>>(cacheKey, offersToCache);
        }
    }
}
