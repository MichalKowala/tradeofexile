using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models.EntityItems
{
    public class UniqueNameEntry : BaseEntity
    {
        public string Name { get; set; }
        public ItemCategory ItemCategory { get; set; }
    }
}
