using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Queries.GetCurrencies
{
    public class GetCurrenciesQuery : IRequest<List<ExchangeOfferDTO>>
    {
        public LeagueType League { get; set; }
        public string CacheKey { get; set; }
        public GetCurrenciesQuery(LeagueType league, string cacheKey)
        {
            League = league;
            CacheKey = cacheKey;
        }
    }
    
}
