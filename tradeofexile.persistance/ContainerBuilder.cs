using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.persistance.Repositories;

namespace tradeofexile.persistance
{
    public static class ContainerBuilder
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<TradeOfExileDbContext>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
