using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using tradeofexile.application.Abstraction;

namespace tradeofexile.infrastructure
{
    public  class ApiHelper : IApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public  void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public string GetResponseFromApi(string url = "http://api.pathofexile.com/public-stash-tabs/")
        {
            InitializeClient();
            HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result;
            var responsejson = response.Content.ReadAsStringAsync();
            return responsejson.Result;
        }
    }
}
