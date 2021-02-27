using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using tradeofexile.models;
using tradeofexile.models.Items;
using System.Linq;

namespace tradeofexile.infrastructure
{
    public static class Parser
    {
        public static Stash ParseResponseStashIntoObjectStash(ResponseStash responseStash)
        {
            Stash stash = new Stash();
            stash.Id = responseStash.Id;
            stash.IsPublic = responseStash.IsPublic;
            stash.AccountName = responseStash.AccountName;
            stash.League = ParseStringLeagueToObjectLeague(responseStash.League);
            foreach (ResponseItem responseItem in responseStash.Items)
                stash.Items.Add(ParseResponseItemIntoObjectItem(responseItem));
            return stash;
        }
        public static Item ParseResponseItemIntoObjectItem(ResponseItem responseItem)
        {
            Item item = new Item();
            item.Name = responseItem.Name;
            item.League = ParseStringLeagueToObjectLeague(responseItem.League);
            item.Id = responseItem.Id;
            item.Extended.Category = ParseStringCategoryToObjectCategory(responseItem.Extended.Category);
            item.IconLink = responseItem.IconLink;
            if (responseItem.Price != null)
                item.Price = ParseStringPriceToObjectPrice(responseItem.Price);
            return item;
        }
        private static ItemCategory ParseStringCategoryToObjectCategory(string stringCategory)
        {
            if (stringToEnumItemCategory.ContainsKey(stringCategory))
                return stringToEnumItemCategory[stringCategory];
            else
                return ItemCategory.Unspecified;
        }
        public static LeagueType ParseStringLeagueToObjectLeague(string stringLeague)
        {
            if (stringToEnumLeague.ContainsKey(stringLeague))
                return stringToEnumLeague[stringLeague];
            return LeagueType.Other;
        }
        public static Price ParseStringPriceToObjectPrice(string stringPrice)
        {
            string[] words = stringPrice.Split(' ');
            Price price = new Price();
            for (int i = 0; i < words.Count(); i++)
            {
                if (stringToEnumCurrency.ContainsKey(words[i]))
                {
                    price.CurrencyType = stringToEnumCurrency[words[i]];
                    words[i - 1].Replace('.', ',');
                    double.TryParse(words[i - 1], out price.Ammount);
                    break;
                }
                else
                {
                    price.CurrencyType = CurrencyType.Unspecified;
                }
            }
            return price;
        }
        private static readonly Dictionary<string, ItemCategory> stringToEnumItemCategory = new Dictionary<string, ItemCategory>()
        {
            {"gems",ItemCategory.Gems },
            {"weapons",ItemCategory.Weapons },
            {"armour",ItemCategory.Armour},
            { "jewels",ItemCategory.Jewels },
            { "maps",ItemCategory.Maps},
            { "accessories", ItemCategory.Accessories},
            {"watchstones", ItemCategory.Watchstones},
            { "monsters",ItemCategory.Monsters},
            {"flasks", ItemCategory.Flasks},
            {"heistequipment",ItemCategory.HeistEquipment},
            {"heistmission",ItemCategory.HeistMissions},
            {"currency",ItemCategory.Currency },
            {"cards", ItemCategory.Cards },
        };
        private static readonly Dictionary<string, CurrencyType> stringToEnumCurrency = new Dictionary<string, CurrencyType>()
        {
            {"chaos",CurrencyType.ChaosOrb },
            {"exalted",CurrencyType.ExaltedOrb },
            {"exa",CurrencyType.ExaltedOrb },
            {"alch",CurrencyType.AlchemyOrb},
            {"jewellers",CurrencyType.JewellersOrb },
            {"gcp",CurrencyType.GemcuttersPrism },
            {"chisel",CurrencyType.Chisel },
            {"alt",CurrencyType.AlterationOrb },
            {"fusing",CurrencyType.FusingOrb },
            {"divine",CurrencyType.DivineOrb },
            {"mirror",CurrencyType.Mirror }
        };
        private static readonly Dictionary<string, LeagueType> stringToEnumLeague = new Dictionary<string, LeagueType>()
        {
            {"Ritual",LeagueType.Ritual },
            {"Standard",LeagueType.Standard },
            {"Hardcore Ritual",LeagueType.HardcoreRitual }
        };
    }
}
