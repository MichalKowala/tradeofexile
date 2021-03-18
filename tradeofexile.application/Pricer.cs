using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Items;
using System.Linq;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.models.EntityItems;

namespace tradeofexile.infrastructure
{
    public  class Pricer : IPricer
    {
      
        private readonly IBaseRepository<CurrencyExchangeOffer> _currencyExchangeOfferRepository;
        public Pricer(IBaseRepository<CurrencyExchangeOffer> currencyExchangeOffer)
        {
  
            _currencyExchangeOfferRepository = currencyExchangeOffer;
        }
       
        public void AddOffer(CurrencyType fromCurrency, Price offer)
        {
            CurrencyExchangeOffer offerRecord = new CurrencyExchangeOffer()
            {
                FromCurrency = fromCurrency,
                ToCurrency = offer.CurrencyType,
                Rate = 1 / offer.Ammount
            };
            _currencyExchangeOfferRepository.Create(offerRecord);
        }
        public Price GetRate(CurrencyType fromCurrency, CurrencyType toCurrency)
        {
            int divider = 0;
            double rate = 0;
            var offers = _currencyExchangeOfferRepository.GetAll().Where(x => x.FromCurrency == fromCurrency && x.ToCurrency == toCurrency);
            foreach (CurrencyExchangeOffer offer in offers)
            {
                divider++;
                rate += offer.Rate;
            }
            if (divider != 0)
                return new Price(rate / divider, toCurrency);
            else return new Price(1, fromCurrency);
        }
    }
}
