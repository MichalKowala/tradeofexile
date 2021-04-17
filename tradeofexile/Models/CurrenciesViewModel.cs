using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;

namespace tradeofexile.Models
{
    public class CurrenciesViewModel
    {
        public PagingInfo PagingInfo { get; set; }
        public List<ExchangeOfferDTO> ExchangeOffers { get; set; }
    }
}
