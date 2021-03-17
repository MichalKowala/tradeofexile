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
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure
{
    public class ResponseHandler : IResponseHandler
    {
        private readonly string _url= "http://api.pathofexile.com/public-stash-tabs/";
        private readonly IApiHelper _apiHelper;
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IParser _parser;
        private readonly IBaseRepository<ResponseHandlerHelper> _responseHandlerHelperRepository;
        public ResponseHandler(IApiHelper apiHelper, IBaseRepository<Item> itemRepository, IParser parser, IBaseRepository<ResponseHandlerHelper> responseHandlerHelperResitory)
        {
            _apiHelper = apiHelper;
            _itemRepository = itemRepository;
            _parser = parser;
            _responseHandlerHelperRepository = responseHandlerHelperResitory;
        }
        public void GetAndProcessPoeApiResponse()
        {
            PoeApiResponse response = GetResponseFromPoeApi();
            ProcessResponse(response);
        }
        private void ProcessResponse(PoeApiResponse response)
        {
            List<Stash> stashes = new List<Stash>();
            foreach (ResponseStash responseStash in response.Stashes)
            {
                stashes.Add(_parser.ParseResponseStashIntoObjectStash(responseStash));
            }
            stashes = Filter.ApplyAllFilters(stashes);
            foreach (Stash stash in stashes)
            {
                foreach (Item item in stash.Items)
                {
                    _itemRepository.Create(item);
                }
            }
        }
        private PoeApiResponse GetResponseFromPoeApi()
        {
            ResponseHandlerHelper oldHelper = _responseHandlerHelperRepository.GetRecentlyCreated();
            var jsonResponse = _apiHelper.GetResponseFromApi(_url + oldHelper.NextCallId);
            PoeApiResponse classResponse = JsonConvert.DeserializeObject<PoeApiResponse>(jsonResponse);
            ResponseHandlerHelper newHelper = new ResponseHandlerHelper();
            newHelper.NextCallId = classResponse.Next_Change_Id;
            _responseHandlerHelperRepository.Create(newHelper);
            return classResponse;
        }
    }
}
