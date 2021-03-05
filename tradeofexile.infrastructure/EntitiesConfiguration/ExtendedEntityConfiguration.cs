using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.Infrastructure.EntitiesConfiguration;
using tradeofexile.models.Items;

namespace tradeofexile.infrastructure.EntitiesConfiguration
{
    public class ExtendedEntityConfiguration : BaseEntityConfiguration<Extended>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Extended> builder)
        {
            builder.HasOne(x => x.Item).WithOne(x => x.Extended).HasForeignKey<Item>(x=>x.Id);
            builder.ToTable("Extended");
        }
    }
}
