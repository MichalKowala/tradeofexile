using Microsoft.EntityFrameworkCore;
using tradeofexile.models.Items;

namespace tradeofexile.persistance
{ 
    public class TradeOfExileDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Extended> Extendeds { get; set; }
        public DbSet <Price> Prices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tradeofexiledb;user=root;pwd=HasloMaslo");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
        }
    }
}
