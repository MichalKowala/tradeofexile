using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using tradeofexile.models;
using tradeofexile.models.Items;
using System.Linq;
using tradeofexile.models.Enums;
using tradeofexile.application.Abstraction;

namespace tradeofexile.infrastructure
{
    public  class Parser : IParser
    {
        public  Stash ParseResponseStashIntoObjectStash(ResponseStash responseStash)
        {
            Stash stash = new Stash();
            stash.IsPublic = responseStash.IsPublic;
            stash.AccountName = responseStash.AccountName;
            stash.League = ParseStringLeagueToObjectLeague(responseStash.League);
            foreach (ResponseItem responseItem in responseStash.Items)
                stash.Items.Add(ParseResponseItemIntoObjectItem(responseItem));
            return stash;
        }
        public  Item ParseResponseItemIntoObjectItem(ResponseItem responseItem)
        {
            Item item = new Item();
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
        public  ItemCategory ParseStringCategoryToObjectCategory(string stringCategory)
        {
            if (stringToEnumItemCategory.ContainsKey(stringCategory))
                return stringToEnumItemCategory[stringCategory];
            else
                return ItemCategory.Unspecified;
        }
        public  LeagueType ParseStringLeagueToObjectLeague(string stringLeague)
        {
            if (stringToEnumLeague.ContainsKey(stringLeague))
                return stringToEnumLeague[stringLeague];
            return LeagueType.Other;
        }
        public  Price ParseStringPriceToObjectPrice(string stringPrice)
        {
            string[] words = stringPrice.Split(' ');
            Price price = new Price(new double(), CurrencyType.Unspecified);
            for (int i = 0; i < words.Count(); i++)
            {
                if (stringToEnumCurrency.ContainsKey(words[i]))
                {
                    price.CurrencyType = stringToEnumCurrency[words[i]];
                    words[i - 1].Replace('.', ',');
                    double ammount;
                    double.TryParse(words[i - 1], out ammount);
                    price.Ammount = ammount;
                    break;
                }
                else
                {
                    price.CurrencyType = CurrencyType.Unspecified;
                }
            }
            return price;
        }
        public  readonly Dictionary<ItemCategory, List<GamepediaItemClass>> itemCategoryToGamepediaItemClass = new Dictionary<ItemCategory, List<GamepediaItemClass>>()
        {
            { ItemCategory.Weapons,new List<GamepediaItemClass>(){
                GamepediaItemClass.Bows,
                GamepediaItemClass.Claws,
                GamepediaItemClass.OneHandAxes,
                GamepediaItemClass.Sceptres,
                GamepediaItemClass.Staves,
                GamepediaItemClass.TwoHandAxes,
                GamepediaItemClass.TwoHandMaces,
                GamepediaItemClass.Wands,
            }},
            {ItemCategory.Jewels, new List<GamepediaItemClass>(){GamepediaItemClass.Jewels} }



        };
        private  readonly Dictionary<string, ItemCategory> stringToEnumItemCategory = new Dictionary<string, ItemCategory>()
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
        public  readonly Dictionary<string, CurrencyType> stringToEnumCurrency = new Dictionary<string, CurrencyType>()
        {
            {"alt",CurrencyType.AlterationOrb },
            {"Ancient Orb", CurrencyType.AncientOrb },
            { "Chaos Orb",CurrencyType.ChaosOrb},
            {"chaos",CurrencyType.ChaosOrb },
            {"Divine Orb",CurrencyType.DivineOrb },
            {"divine",CurrencyType.DivineOrb },
            {"Exalted Orb",CurrencyType.ExaltedOrb },
            {"exalted",CurrencyType.ExaltedOrb },
            {"exa",CurrencyType.ExaltedOrb },
            {"Orb of Alchemy",CurrencyType.AlchemyOrb },
            {"alch",CurrencyType.AlchemyOrb},
            {"jewellers",CurrencyType.JewellersOrb },
            {"gcp",CurrencyType.GemcuttersPrism },
            {"chisel",CurrencyType.Chisel },
            {"Orb of Fusing",CurrencyType.FusingOrb },
            {"Orb of Augmentation",CurrencyType.OrbOfAugmentation },
            {"Vaal Orb",CurrencyType.VaalOrb },
            {"fusing",CurrencyType.FusingOrb },
            {"mirror",CurrencyType.Mirror }
        };
        private  readonly Dictionary<string, LeagueType> stringToEnumLeague = new Dictionary<string, LeagueType>()
        {
            {"Ritual",LeagueType.Ritual },
            {"Standard",LeagueType.Standard },
            {"Hardcore Ritual",LeagueType.HardcoreRitual }
        };

        public  Dictionary<string, CurrencyType> GetStringToEnumCurrency()
        {
            return stringToEnumCurrency;
        }
        public Dictionary<ItemCategory, List<GamepediaItemClass>> GetItemCategorytoGamediaItemClassDictionary()
        {
            return itemCategoryToGamepediaItemClass;
        }
    }
}
