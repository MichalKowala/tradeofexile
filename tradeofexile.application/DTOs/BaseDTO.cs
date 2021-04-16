using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.application.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
