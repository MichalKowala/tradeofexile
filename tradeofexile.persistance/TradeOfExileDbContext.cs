using Microsoft.EntityFrameworkCore;
using tradeofexile.models.EntityItems;
using tradeofexile.models.EntityItems;
using tradeofexile.persistance.EntitiesConfiguration;

namespace tradeofexile.persistance
{ 
    public class TradeOfExileDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Extended> Extendeds { get; set; }
        public DbSet <Price> Prices { get; set; }
        public DbSet <ResponseHandlerHelper> ResponseHandlerHelpers { get; set; }
        public DbSet <CurrencyExchangeOffer> CurrencyExchangeOffers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tradeofexiledb;user=root;pwd=HasloMaslo");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExtendedEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PriceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseHandlerHelperEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyExchangeOfferConfiguration());
        }
    }
}
