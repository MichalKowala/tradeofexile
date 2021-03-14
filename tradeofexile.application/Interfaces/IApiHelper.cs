using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.application.Abstraction
{
    public interface IApiHelper
    {
        public string GetResponseFromApi(string url = "http://api.pathofexile.com/public-stash-tabs/");
        public void InitializeClient();
    }
}
