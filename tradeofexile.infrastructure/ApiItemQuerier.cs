using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;

namespace tradeofexile.infrastructure
{
    public static class ApiItemQuerier
    {

        private static readonly string baseUrl = "https://pathofexile.gamepedia.com/api.php?action=cargoquery&tables=items&fields=name";
        public static string GetItemAndRarityParametriziedGamepediaCallUrl(ItemClass itemClass, ItemRarity itemRarity, ResponseFormat responseFormat)
        {
            string parametriziedUrl = ApplyWhereClauseToUrl(baseUrl);
            parametriziedUrl = ApplyClassParameterToUrl(itemClass, parametriziedUrl);
            parametriziedUrl = ApplyAndClauseToUrl(parametriziedUrl);
            parametriziedUrl = ApplyRarityParameterToUrl(itemRarity, parametriziedUrl);
            parametriziedUrl = ApplyFormatParameterToUrl(responseFormat, parametriziedUrl);
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
        private static string ApplyClassParameterToUrl(ItemClass itemClass, string url)
        {
            return $"{url}class=%22{itemClassToUrlClassParameterDictionary[itemClass]}%22";
        }
        private static string ApplyRarityParameterToUrl(ItemRarity itemRarity, string url)
        {
            return $"{url}rarity=%22{itemRarityToUrlRarityParameterDictionary[itemRarity].ToString()}%22";
        }
        private static string ApplyFormatParameterToUrl(ResponseFormat format, string url)
        {
            return $"{url}&format={format}";
        }
        private static readonly Dictionary<ItemClass, string> itemClassToUrlClassParameterDictionary = new Dictionary<ItemClass, string>()
        {
            { ItemClass.Daggers,"Daggers" },
            { ItemClass.Claws,"Claws"},
            { ItemClass.OneHandSwords,"One Hand Swords" },
            { ItemClass.ThrustingOneHandSwords,"Thrusting One Hand Swords" },
            { ItemClass.OneHandAxes, "One Hand Axes" },
            { ItemClass.Bows,"Bows"},
            { ItemClass.Wands,"Wands" },
            { ItemClass.Staves,"Staves" },
            { ItemClass.TwoHandAxes,"Two Hand Axes" },
            { ItemClass.TwoHandMaces,"Two Hand Maces" },
            { ItemClass.Sceptres,"Sceptres" },
            { ItemClass.LifeFlasks,"Life Flasks" },
            { ItemClass.ManaFlasks,"Mana Flasks" },
            { ItemClass.HybridFlasks,"Hybrid Flasks" },
            { ItemClass.UtilityFlasks,"Utility Flasks" },
            { ItemClass.CriticalUtilityFlasks,"Critical Utility Flasks" },
            { ItemClass.Jewels,"Jewel" }

        };
        private static Dictionary<ItemRarity, string> itemRarityToUrlRarityParameterDictionary = new Dictionary<ItemRarity, string>()
        {
            {ItemRarity.Unique,"Unique" }
        };
    }
}
