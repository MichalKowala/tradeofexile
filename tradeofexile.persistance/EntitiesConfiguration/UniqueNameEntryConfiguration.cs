using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.persistance.EntitiesConfiguration
{
    public class UniqueNameEntryConfiguration : BaseEntityConfiguration<UniqueNameEntry>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UniqueNameEntry> builder)
        {
            builder.ToTable("UniqueItemNames");
        }
    }
}
