﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tradeofexile.models.Items;

namespace tradeofexile.persistance.EntitiesConfiguration
{
    public class PriceEntityConfiguration : BaseEntityConfiguration<Price>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");
        }
    }
}