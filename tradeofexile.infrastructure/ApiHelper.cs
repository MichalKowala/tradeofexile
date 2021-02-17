using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace tradeofexile.infrastructure
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static string GetResponseFromPoeApi()
        {
            string url = "http://api.pathofexile.com/public-stash-tabs";
            HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result;
            var responsejson = response.Content.ReadAsStringAsync();
            return responsejson.Result;
        }
    }
}
