using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.persistance.EntitiesConfiguration
{
    public class CurrencyExchangeOfferConfiguration : BaseEntityConfiguration<CurrencyExchangeOffer>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CurrencyExchangeOffer> builder)
        {
            builder.ToTable("ExchangeTable");
        }
    }
}
