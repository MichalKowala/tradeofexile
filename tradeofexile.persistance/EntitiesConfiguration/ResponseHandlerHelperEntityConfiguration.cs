using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.persistance.EntitiesConfiguration
{
    class ResponseHandlerHelperEntityConfiguration : BaseEntityConfiguration<ResponseHandlerHelper>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ResponseHandlerHelper> builder)
        {
            builder.ToTable("ResponeHandlerHelpers");
        }
    }
}
