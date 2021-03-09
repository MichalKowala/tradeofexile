using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;

namespace tradeofexile.infrastructure
{
    public static class ApiItemQuerier
    {

        private static readonly string baseUrl = "https://pathofexile.gamepedia.com/api.php?action=cargoquery&tables=items&fields=name";
        public static string GetItemAndRarityParametriziedGamepediaCallUrl(GamepediaItemClass itemClass, ItemRarity itemRarity, ResponseFormat responseFormat)
        {
            string parametriziedUrl = ApplyWhereClauseToUrl(baseUrl);
            parametriziedUrl = ApplyClassParameterToUrl(itemClass, parametriziedUrl);
            parametriziedUrl = ApplyAndClauseToUrl(parametriziedUrl);
            parametriziedUrl = ApplyRarityParameterToUrl(itemRarity, parametriziedUrl);
            parametriziedUrl = ApplyFormatParameterToUrl(responseFormat, parametriziedUrl);
            parametriziedUrl += "&limit=500";
            return parametriziedUrl;
        }
        
        private static string ApplyWhereClauseToUrl(string url)
        {
            return $"{url}&where=";
        }
        private static string ApplyAndClauseToUrl(string url)
        {
            return $"{url} AND ";
        }
        private static string ApplyClassParameterToUrl(GamepediaItemClass itemClass, string url)
        {
            return $"{url}class=%22{gamepediaItemClassToUrlParameter[itemClass]}%22";
        }
        private static string ApplyRarityParameterToUrl(ItemRarity itemRarity, string url)
        {
            return $"{url}rarity=%22{itemRarityToUrlRarityParameterDictionary[itemRarity].ToString()}%22";
        }
        private static string ApplyFormatParameterToUrl(ResponseFormat format, string url)
        {
            return $"{url}&format={format}";
        }
        private static readonly Dictionary<GamepediaItemClass, string> gamepediaItemClassToUrlParameter = new Dictionary<GamepediaItemClass, string>()
        {
            { GamepediaItemClass.Daggers,"Daggers" },
            { GamepediaItemClass.Claws,"Claws"},
            { GamepediaItemClass.OneHandSwords,"One Hand Swords" },
            { GamepediaItemClass.ThrustingOneHandSwords,"Thrusting One Hand Swords" },
            { GamepediaItemClass.OneHandAxes, "One Hand Axes" },
            { GamepediaItemClass.Bows,"Bows"},
            { GamepediaItemClass.Wands,"Wands" },
            { GamepediaItemClass.Staves,"Staves" },
            { GamepediaItemClass.TwoHandAxes,"Two Hand Axes" },
            { GamepediaItemClass.TwoHandMaces,"Two Hand Maces" },
            { GamepediaItemClass.Sceptres,"Sceptres" },
            { GamepediaItemClass.LifeFlasks,"Life Flasks" },
            { GamepediaItemClass.ManaFlasks,"Mana Flasks" },
            { GamepediaItemClass.HybridFlasks,"Hybrid Flasks" },
            { GamepediaItemClass.UtilityFlasks,"Utility Flasks" },
            { GamepediaItemClass.CriticalUtilityFlasks,"Critical Utility Flasks" },
            { GamepediaItemClass.Jewels,"Jewel" }

        };
        private static Dictionary<ItemRarity, string> itemRarityToUrlRarityParameterDictionary = new Dictionary<ItemRarity, string>()
        {
            {ItemRarity.Unique,"Unique" }
        };
    }
}
