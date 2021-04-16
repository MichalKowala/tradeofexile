using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.DTOs;
using tradeofexile.application.Interfaces;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interactors
{
    public class ExchangeOffersInteractor : IExchangeOffersInteractor
    {
        private readonly IBaseRepository<CurrencyExchangeOffer> _currencyRepository;
        public ExchangeOffersInteractor(IBaseRepository<CurrencyExchangeOffer> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public List<ExchangeOfferDTO> GetOffersToCache()
        {
            var unprocessed = _currencyRepository.GetAll();
            var currenciesCount = Enum.GetNames(typeof(CurrencyType)).Length;
            List<ExchangeOfferDTO> offers = new List<ExchangeOfferDTO>();
            for (int i = 0; i < currenciesCount; i++)
            {
                ExchangeOfferDTO offer = new ExchangeOfferDTO();
                offer.CurrencyType=(CurrencyType)i;

                var buyOffers = unprocessed.Where(x => x.ToCurrency == offer.CurrencyType).ToList();
                if (buyOffers.Count() != 0)
                {
                    var buyMostCommon = buyOffers.GroupBy(x => x.FromCurrency).OrderByDescending(x => x.Count()).First();
                    int buyDivider = 0;
                    double buyRateCombined = 0;
                    foreach (var buyOffer in buyMostCommon)
                    {
                        buyDivider++;
                        buyRateCombined += buyOffer.Rate;
                    }
                    offer.BuyType = buyMostCommon.Key;
                    offer.BuyRate = buyRateCombined / buyDivider;
                }

                var sellOffers = unprocessed.Where(x => x.FromCurrency == offer.CurrencyType).ToList();
                if(sellOffers.Count()!=0)
                {
                    var sellMostCommon = sellOffers.GroupBy(x => x.ToCurrency).OrderByDescending(x => x.Count()).First();
                    int sellDivider = 0;
                    double sellRateCombinder = 0;
                    foreach (var sellOffer in sellMostCommon)
                    {
                        sellDivider++;
                        sellRateCombinder += sellOffer.Rate;
                    }
                    offer.SellType = sellMostCommon.Key;
                    offer.SellRate = sellRateCombinder / sellDivider;
                }
                offers.Add(offer);
            }
            return offers;
        }
    }
}
