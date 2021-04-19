using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Services
{
    public class CurrenciesService : ICurrenciesService
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly IExchangeOffersInteractor _exchangeOffersInteractor;
        public CurrenciesService(ICacheProvider cacheProvider, IExchangeOffersInteractor exchangeOffersInteractor)
        {
            _cacheProvider = cacheProvider;
            _exchangeOffersInteractor = exchangeOffersInteractor;
        }
        public List<ExchangeOfferDTO> GetCachedCurrencies(string cacheKey, LeagueType league)
        {
            var result = _cacheProvider.GetFromCache<List<ExchangeOfferDTO>>(cacheKey);
            if (result != null)
                return result.Where(x => x.League == league).ToList();
            else
            {
                CacheCurrencies(cacheKey);
                result = _cacheProvider.GetFromCache<List<ExchangeOfferDTO>>(cacheKey);
                return result.Where(x => x.League == league).ToList();
            }
        }


        public void CacheCurrencies(string cacheKey)
        {
            var offersToCache = _exchangeOffersInteractor.GetOffersToCache();
            _cacheProvider.SetCache<List<ExchangeOfferDTO>>(cacheKey, offersToCache);
        }
    }
}
