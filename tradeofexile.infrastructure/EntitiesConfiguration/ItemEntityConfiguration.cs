using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.Infrastructure.EntitiesConfiguration;
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure.EntitiesConfiguration
{
    public class ItemEntityConfiguration : BaseEntityConfiguration<Item>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(x => x.Price).WithOne(x => x.Item).HasForeignKey<Price>(x => x.ItemId);
            builder.HasOne(x => x.Extended).WithOne(x => x.Item).HasForeignKey<Extended>(x => x.ItemId);
            builder.ToTable("Items");
        }
    }
}
