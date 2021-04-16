using System.Collections.Generic;
using tradeofexile.application.DTOs;

namespace tradeofexile.Models
{
    public class ItemsViewModel
    {
        public List<ItemDTO> ItemsToShow { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}
