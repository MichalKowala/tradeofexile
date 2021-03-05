
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Infrastructure.EntitiesConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            ConfigureEntity(builder);
        }
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
