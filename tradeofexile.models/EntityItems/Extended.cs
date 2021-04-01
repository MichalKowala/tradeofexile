using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models.EntityItems
{
    public class Extended : BaseEntity
    {
        public ItemCategory Category { get; set; } = ItemCategory.Unspecified;
        public string BaseType { get; set; }
        public Guid? ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
