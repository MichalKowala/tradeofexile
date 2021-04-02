using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using tradeofexile.application.Abstraction;
using tradeofexile.models.Enums;
using tradeofexile.models.EntityItems;
using tradeofexile.application.Contracts.Persistence;
using System;
using System.Linq;
using tradeofexile.application;

namespace tradeofexile.infrastructure
{
    public  class GamepediaResponseHandler : IGamepediaResponseHandler
    {
        private readonly IApiItemQuerier _apiItemQuerier;
        private readonly IApiHelper _apiHelper;
        private readonly IParser _parser;
        private readonly IBaseRepository<UniqueNameEntry> _uniqueNamesRepository;
        public GamepediaResponseHandler(IApiItemQuerier apiItemQuerier, IApiHelper apiHelper, IParser parser, IBaseRepository<UniqueNameEntry> uniqueNamesRepository)
        {
            _apiItemQuerier = apiItemQuerier;
            _apiHelper = apiHelper;
            _parser = parser;
            _uniqueNamesRepository = uniqueNamesRepository;
        }
        public  List<string> GetUniqueNames(GamepediaItemClass itemClass)
        {
            List<string> names = new List<string>();
            string gamepediaCallUrl = _apiItemQuerier.GetParametriziedGamepediaCallUrl(itemClass, ItemRarity.Unique, ResponseFormat.json);
            string response = _apiHelper.GetResponseFromApi(gamepediaCallUrl + "&format=json");
            JObject jObject = JObject.Parse(response);
            foreach (JToken t in jObject["cargoquery"])
            {
                JToken token = t.Value<JToken>("title");
                names.Add(token.Value<string>("name"));
            }
            return names;
        }
        public  List<string> GetUniqueNames(ItemCategory itemCategory)
        {
            List<string> names = new List<string>();
            try
            {
                List<GamepediaItemClass> itemClasses = ParsingTable.itemCategoryToGamepediaItemClass[itemCategory];
                foreach (GamepediaItemClass itemClass in itemClasses)
                {
                    names.AddRange(GetUniqueNames(itemClass));
                }
            }
            catch 
            {
                
            }
            return names;
        }

        public void UpdateUniqueNames()
        {
            int categoriesCount = Enum.GetNames(typeof(ItemCategory)).Length;
            for (int i=0; i<=categoriesCount; i++)
            {
                List<string> uniques=GetUniqueNames((ItemCategory)i);
                foreach (string name in uniques)
                {
                    if (!_uniqueNamesRepository.Exists(x => x.Name == "Steel Spirit"))
                    {
                        _uniqueNamesRepository.Create(new UniqueNameEntry() { Name = name, ItemCategory = (ItemCategory)i });
                    }
                }
            }
        }

        public  List<string> GetListOfCurrencyItems()
        {
            List<string> listOfItems = new List<string>();
            string poeWatchCallUrl = "https://api.poe.watch/get?category=currency&league=Ritual";
            string response = _apiHelper.GetResponseFromApi(poeWatchCallUrl);
            JArray jArray = JArray.Parse(response);
            foreach (JToken t in jArray)
            {
                listOfItems.Add(t.Value<string>("name"));
            }
            return listOfItems;
        }
    }
}
