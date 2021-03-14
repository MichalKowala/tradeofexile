using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.Interactors;
using tradeofexile.infrastructure;

namespace tradeofexile.application
{
    public static class ContainerBuilder
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddTransient<IApiHelper, ApiHelper>();
            services.AddTransient<IApiItemQuerier, ApiItemQuerier>();
            services.AddTransient<IItemExtensions, ItemExtensions>();
            services.AddTransient<IItemInteractor, ItemInteractor>();
            services.AddTransient<IParser, Parser>();
            services.AddTransient<IPricer, Pricer>();
            return services;
        }
    }

}
