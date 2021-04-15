using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using tradeofexile.models;
using tradeofexile.models.EntityItems;
using System.Linq;
using tradeofexile.models.Enums;
using tradeofexile.application.Abstraction;
using tradeofexile.application;

namespace tradeofexile.infrastructure
{
    public class Parser : IParser
    {
        public Stash ParseResponseStashIntoObjectStash(ResponseStash responseStash)
        {
            Stash stash = new Stash();
            stash.ResponseId = responseStash.Id;
            stash.IsPublic = responseStash.IsPublic;
            stash.AccountName = responseStash.AccountName;
            if (responseStash.League != null)
                stash.League = ParseStringLeagueToObjectLeague(responseStash.League);
            foreach (ResponseItem responseItem in responseStash.Items)
                stash.Items.Add(ParseResponseItemIntoObjectItem(responseItem));
            return stash;
        }
        public Item ParseResponseItemIntoObjectItem(ResponseItem responseItem)
        {
            Item item = new Item();
            item.ResponseId = responseItem.Id;
            item.Name = responseItem.Name;
            item.League = ParseStringLeagueToObjectLeague(responseItem.League);
            item.Extended = new Extended();
            item.Extended.BaseType = responseItem.Extended.BaseType;
            item.Extended.Category = ParseStringCategoryToObjectCategory(responseItem.Extended.Category);
                
            item.IconLink = responseItem.IconLink;
            if (responseItem.Price != null)
                item.Price = ParseStringPriceToObjectPrice(responseItem.Price);
            return item;
        }
        public ItemCategory ParseStringCategoryToObjectCategory(string stringCategory)
        {
            if (ParsingTable.stringToEnumItemCategory.ContainsKey(stringCategory))
                return ParsingTable.stringToEnumItemCategory[stringCategory];
            else
                return ItemCategory.Unspecified;
        }
        public LeagueType ParseStringLeagueToObjectLeague(string stringLeague)
        {
            if (ParsingTable.stringToEnumLeague.ContainsKey(stringLeague))
                return ParsingTable.stringToEnumLeague[stringLeague];
            return LeagueType.Other;
        }
        public Price ParseStringPriceToObjectPrice(string stringPrice)
        {
            string[] words = stringPrice.Split(' ');
            Price price = new Price();
            for (int i = 0; i < words.Count(); i++)
            {
                if (ParsingTable.stringToEnumCurrency.ContainsKey(words[i]))
                {
                    price.CurrencyType = ParsingTable.stringToEnumCurrency[words[i]];
                    price.Ammount = ParseStringToDouble(words[i - 1]);
                    if (price.Ammount > 0)
                        return price;
                    else return null;
                }
            }
            return null;
        }
        
        private double ParseStringToDouble(string value)
        {
            double number = new double();
            value = value.Replace(".", ",");
            if (value.Contains('/'))
            {
                Double.TryParse(value.Split('/').ElementAt(0), out double numerator);
                Double.TryParse(value.Split('/').ElementAt(1), out double denominator);
                number = numerator / denominator;
                return number;
            }
            Double.TryParse(value, out number);
            return number;
        }
             
    }
}
