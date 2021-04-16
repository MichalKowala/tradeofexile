using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.DTOs;

namespace tradeofexile.application.Interfaces
{
    public interface IExchangeOffersInteractor
    {
        public List<ExchangeOfferDTO> GetOffersToCache();
    }
}
