using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.models.EntityItems;

namespace tradeofexile.persistance.EntitiesConfiguration
{
    public class ExtendedEntityConfiguration : BaseEntityConfiguration<Extended>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Extended> builder)
        {
            builder.HasOne<Item>(x => x.Item).WithOne(x => x.Extended).HasForeignKey<Extended>(x => x.ItemId);
            builder.ToTable("Extendeds");
        }
    }
}
