using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using tradeofexile.infrastructure.Context;
using tradeofexile.models;
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();
            PoeApiResponse response = FakeLoop.GetResponseAsObject("https://www.pathofexile.com/api/public-stash-tabs?id=1087297762-1095368139-1053974654-1183926836-1136054818");
            List<Item> itemki = new List<Item>();
            itemki.AddRange(Smietnik.DajFakeoweItemki());
            foreach (ResponseStash rS in response.Stashes)
            {
                foreach (ResponseItem rI in rS.Items)
                {
                    Item i = Parser.ParseResponseItemIntoObjectItem(rI);
                    itemki.Add(i);
                    
                }
            }
            foreach (Item i in itemki)
            {
                if (i.Price!=null)
                {
                    Pricer.AddPricedItemToDictionary(i);
                }
            }
            using (var context=new TradeOfExileDbContext())
            {
                
            }
            // Pricer.GetRate(CurrencyType.ExaltedOrb, CurrencyType.AncientOrb);
           // Price dupaa = Pricer.GetRate(CurrencyType.ExaltedOrb, CurrencyType.ChaosOrb);
            Console.WriteLine("tesT");
        }
    }
}
