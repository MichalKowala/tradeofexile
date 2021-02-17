using Newtonsoft.Json.Linq;
using System;

namespace tradeofexile.infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();

            string jsonString = ApiHelper.GetResponseFromPoeApi();
            JObject jsonObject = JObject.Parse(jsonString);

            Console.WriteLine("tesT");
        }
    }
}
