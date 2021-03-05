using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.Infrastructure.EntitiesConfiguration;
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure.EntitiesConfiguration
{
    public class PriceEntityConfiguration : BaseEntityConfiguration<Price>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");
        }
    }
}
