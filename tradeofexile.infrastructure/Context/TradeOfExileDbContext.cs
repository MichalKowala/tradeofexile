using Microsoft.EntityFrameworkCore;
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure.Context
{
    public class TradeOfExileDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tradeofexiledb;user=root;pwd=HasloMaslo");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(x => x.Id);            
        }
    }
}
