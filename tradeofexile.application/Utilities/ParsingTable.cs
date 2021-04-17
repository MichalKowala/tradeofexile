using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;
using tradeofexile.models.Enums;

namespace tradeofexile.application
{
    public static class ParsingTable
    {
        public static readonly Dictionary<string, ItemCategory> stringToEnumItemCategory = new Dictionary<string, ItemCategory>()
        {
            {"gems",ItemCategory.Gems },
            {"weapons",ItemCategory.Weapons },
            {"armour",ItemCategory.Armour},
            {"jewels",ItemCategory.Jewels },
            {"maps",ItemCategory.Maps},
            {"accessories", ItemCategory.Accessories},
            {"watchstones", ItemCategory.Watchstones},
            {"monsters",ItemCategory.Monsters},
            {"flasks", ItemCategory.Flasks},
            {"heistequipment",ItemCategory.HeistEquipment},
            {"heistmission",ItemCategory.HeistMissions},
            {"currency",ItemCategory.Currency },
            {"cards", ItemCategory.Cards },

        };
        public static readonly Dictionary<string, CurrencyType> stringToEnumCurrency = new Dictionary<string, CurrencyType>()
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
        public static readonly Dictionary<string, LeagueType> stringToEnumLeague = new Dictionary<string, LeagueType>()
        {
            {"Ritual",LeagueType.Ritual },
            {"Standard",LeagueType.Standard },
            {"Hardcore Ritual",LeagueType.HardcoreRitual },
            {"Hardcore", LeagueType.Hardcore }
        };

        public static readonly Dictionary<ItemCategory, List<GamepediaItemClass>> itemCategoryToGamepediaItemClass = new Dictionary<ItemCategory, List<GamepediaItemClass>>()
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

            { ItemCategory.Armour, new List<GamepediaItemClass>()
            {
                GamepediaItemClass.Gloves,
                GamepediaItemClass.Boots,
                GamepediaItemClass.BodyArmours,
                GamepediaItemClass.Helmets,
                GamepediaItemClass.Shields
            }},

            { ItemCategory.Accessories, new List<GamepediaItemClass>()
            {
                GamepediaItemClass.Rings,
                GamepediaItemClass.Amulets,
            }},

            {ItemCategory.Flasks, new List<GamepediaItemClass>()
            {
                GamepediaItemClass.CriticalUtilityFlasks,
                GamepediaItemClass.HybridFlasks,
                GamepediaItemClass.LifeFlasks,
                GamepediaItemClass.ManaFlasks,
                GamepediaItemClass.UtilityFlasks
            }},
            {ItemCategory.Maps, new List<GamepediaItemClass>(){GamepediaItemClass.Maps} },
            {ItemCategory.Jewels, new List<GamepediaItemClass>(){GamepediaItemClass.Jewels} }
        };

        public static readonly Dictionary<CurrencyType, Uri> enumCurrencyToIconUri = new Dictionary<CurrencyType, Uri>()
        {
            { CurrencyType.AlchemyOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyUpgradeToRare.png?w=1&h=1&scale=1") },
            { CurrencyType.AlterationOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollMagic.png?w=1&h=1&scale=1") },
            { CurrencyType.OrbOfAugmentation, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyAddModToMagic.png?w=1&h=1&scale=1") },
            { CurrencyType.AncientOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/AncientOrb.png?w=1&h=1&scale=1") },
            { CurrencyType.ChaosOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollRare.png?w=1&h=1&scale=1") },
            { CurrencyType.DivineOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyModValues.png?w=1&h=1&scale=1") },
            { CurrencyType.ExaltedOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyAddModToRare.png?w=1&h=1&scale=1") },
            { CurrencyType.FusingOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollSocketLinks.png?w=1&h=1&scale=1") },
            { CurrencyType.JewellersOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyRerollSocketNumbers.png?w=1&h=1&scale=1") },
            { CurrencyType.GemcuttersPrism, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyGemQuality.png?w=1&h=1&scale=1") },
            { CurrencyType.Chisel, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyMapQuality.png?w=1&h=1&scale=1") },
            { CurrencyType.Mirror, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyDuplicate.png?w=1&h=1&scale=1") },
            { CurrencyType.VaalOrb, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyVaal.png?w=1&h=1&scale=1") },
            { CurrencyType.OrbOfScouring, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyConvertToNormal.png?w=1&h=1&scale=1") },
            { CurrencyType.Unspecified, new Uri("https://web.poecdn.com/image/Art/2DItems/Currency/CurrencyIdentification.png?w=1&h=1&scale=1") },

        };



    }
}
