using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tradeofexile.Models
{
    public class ItemsViewModel
    {
        public List<ItemModel> ItemsToShow { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}
