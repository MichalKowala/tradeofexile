using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Interactors;
using tradeofexile.application.Interfaces;
using tradeofexile.infrastructure;


namespace tradeofexile.application
{
    public static class ContainerBuilder
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IJobsManager, JobsManager>();
            services.AddTransient<IPoeApiIResponseHandler, PoeApiResponseHandler>();
            services.AddTransient<IApiHelper, ApiHelper>();
            services.AddTransient<IApiItemQuerier, ApiItemQuerier>();
            services.AddTransient<IGamepediaResponseHandler, GamepediaResponseHandler>();
            services.AddTransient<IItemInteractor, ItemInteractor>();
            services.AddTransient<IParser, Parser>();
            services.AddTransient<IPricer, Pricer>();
            services.AddTransient<IPoeApiIResponseHandler, PoeApiResponseHandler>();
            services.AddTransient<IFilter, Filter>();
            services.AddTransient<ICacheProvider, CacheProvider>();
            services.AddTransient<IExchangeOffersInteractor, ExchangeOffersInteractor>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }

}
