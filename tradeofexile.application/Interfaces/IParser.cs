﻿using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models;
using tradeofexile.models.Enums;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Abstraction
{
    public interface IParser
    {
        public Stash ParseResponseStashIntoObjectStash(ResponseStash responseStash);
        public Item ParseResponseItemIntoObjectItem(ResponseItem responseItem);
        public LeagueType ParseStringLeagueToObjectLeague(string stringLeague);
        public Price ParseStringPriceToObjectPrice(string stringPrice);
        public ItemCategory ParseStringCategoryToObjectCategory(string stringCategory);
    }
}
