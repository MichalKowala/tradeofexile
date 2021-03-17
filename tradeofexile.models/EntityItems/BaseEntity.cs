using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models.EntityItems
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }

}
