using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.Interfaces;
using tradeofexile.models;
using tradeofexile.models.EntityItems;
using System.Threading;
using tradeofexile.application;

namespace tradeofexile.infrastructure
{
    public class PoeApiResponseHandler : IPoeApiIResponseHandler
    {
        private readonly string _url= "http://api.pathofexile.com/public-stash-tabs/";
        private readonly IApiHelper _apiHelper;
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IParser _parser;
        private readonly IBaseRepository<ResponseHandlerHelper> _responseHandlerHelperRepository;
        private readonly IFilter _filter;
        private readonly IPricer _pricer;
        public PoeApiResponseHandler(IApiHelper apiHelper, IBaseRepository<Item> itemRepository, IParser parser, IBaseRepository<ResponseHandlerHelper> responseHandlerHelperResitory, IFilter filter, IPricer pricer)
        {
            _apiHelper = apiHelper;
            _itemRepository = itemRepository;
            _parser = parser;
            _responseHandlerHelperRepository = responseHandlerHelperResitory;
            _filter = filter;
            _pricer = pricer;
        }
        public void GetAndProcessPoeApiResponse()
        {
            try
            {
                PoeApiResponse response = GetResponseFromPoeApi();
                ProcessResponse(response);
            }
            catch (Exception e)
            {

            }
        }
        private void ProcessResponse(PoeApiResponse response)
        {
            List<Stash> stashes = GetStashesFromResponse(response);
            List<Item> items = new List<Item>();
            foreach (Stash s in stashes)
            {
                items.AddRange(s.Items);
            }
            ProcessItems(items);
        }

        private List<Stash> GetStashesFromResponse(PoeApiResponse response)
        {   

            List<Stash> stashes = new List<Stash>();
            foreach (ResponseStash responseStash in response.Stashes)
            {
                stashes.Add(_parser.ParseResponseStashIntoObjectStash(responseStash));
            }
            stashes = _filter.ApplyAllFilters(stashes);
            return stashes;
        }
        private void ProcessItems(List<Item> items)
        {
            foreach (Item i in items)
            {
                if (i.Extended.Category==ItemCategory.Currency)
                {
                    if (ParsingTable.stringToEnumCurrency.ContainsKey(i.Extended.BaseType))
                    {
                        _pricer.AddOffer(ParsingTable.stringToEnumCurrency[i.Extended.BaseType], i.Price);
                    }
                }
                else
                    if (i.Price!=null)
                    _itemRepository.Create(i);
            }
        }
        private PoeApiResponse GetResponseFromPoeApi()
        {
            ResponseHandlerHelper oldHelper = _responseHandlerHelperRepository.GetRecentlyCreated();
            var jsonResponse = _apiHelper.GetResponseFromApi(_url + oldHelper.NextCallId);
            PoeApiResponse classResponse = JsonConvert.DeserializeObject<PoeApiResponse>(jsonResponse);
            ResponseHandlerHelper newHelper = new ResponseHandlerHelper();
            newHelper.NextCallId = classResponse.Next_Change_Id;
            if (newHelper.NextCallId!=null)
            _responseHandlerHelperRepository.Create(newHelper);
            return classResponse;
        }
    }
}
