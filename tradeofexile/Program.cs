using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Interactors;
using tradeofexile.infrastructure;
using tradeofexile.models;
using tradeofexile.models.EntityItems;
using tradeofexile.persistance;
using tradeofexile.persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace tradeofexile
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
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
