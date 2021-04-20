using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Queries.GetUniques
{
    public class GetUniquesQuery : IRequest<List<ItemDTO>>
    {
        public LeagueType League { get; set; }
        public ItemCategory Category { get; set; }
        public string CacheKey { get; set; }
        public GetUniquesQuery(LeagueType league, ItemCategory category, string cacheKey)
        {
            League = league;
            Category = category;
            CacheKey = cacheKey;
        }
    }
}
