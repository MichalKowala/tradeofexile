using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.infrastructure;
using tradeofexile.models;
using tradeofexile.models.Items;
using tradeofexile.persistance;
using tradeofexile.persistance.Repositories;

namespace tradeofexile
{
    public class Program
    {
        public static void Main(string[] args)
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
            var dupa = new TradeOfExileDbContext();
            using (var db = new TradeOfExileDbContext())
            {
                foreach (Item i in itemki)
                {
                    dupa.Add(i);

                }
                dupa.SaveChanges();
            }

            ItemRepository repo = new ItemRepository(new TradeOfExileDbContext());
            List<Item> itemy = repo.GetPricedUniquesByItemCategory(ItemCategory.Jewels);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
