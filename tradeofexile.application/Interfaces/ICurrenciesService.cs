using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interfaces
{
    public interface ICurrenciesService
    {
        public List<ExchangeOfferDTO> GetCachedCurrencies(string cacheKey, LeagueType leagueType);
        public void CacheCurrencies(string cacheKey);
    }
}
