using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interactors
{
    public class ItemInteractor : IItemInteractor
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<UniqueNameEntry> _namesRepository;
        private readonly IMapper _mapper;
        public ItemInteractor(IBaseRepository<Item> itemRepository, IBaseRepository<Price> priceRepository, IBaseRepository<UniqueNameEntry> namesRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _namesRepository = namesRepository;
            _mapper = mapper;
            
        }
        public List<ItemDTO> GetUniquesToCache(ItemCategory category)
        {
            var unprocessed = GetUniquesByItemCategory(category);
            return Process(unprocessed);
        }
        public List<ItemDTO> GetDeliriumOrbsToCache()
        {
            var unprocessed = _itemRepository.GetAllWithChildrenAndFilter(x=>x.Extended.BaseType.Contains("Delirium Orb"), x => x.Price, y => y.Extended).ToList();
            foreach (var orb in unprocessed)
                orb.Name = orb.Extended.BaseType;
            var mapped=_mapper.Map<List<Item>,List< ItemDTO >> (unprocessed);
            return Process(mapped);
        }
        private List<ItemDTO> Process(List<ItemDTO> unprocessed)
        {
            var leagueGroupings = unprocessed.GroupBy(x => x.League);
            List<ItemDTO> cacheValue = new List<ItemDTO>();
            foreach (var lG in leagueGroupings)
            {
                var nameLeagueGroupings = lG.GroupBy(x => x.Name);
                foreach (var nLG in nameLeagueGroupings)
                {
                    cacheValue.Add(ProcessNameLeagueGrouping(nLG));
                }
            }
            return cacheValue;
        }
        private List<ItemDTO> GetUniquesByItemCategory(ItemCategory itemCategory)
        {
            var nameEntries = _namesRepository.GetAll(x => x.ItemCategory == itemCategory).ToList();
            var names = new List<string>();
            foreach (UniqueNameEntry entry in nameEntries)
            {
                names.Add(entry.Name);
            }
            var items = _itemRepository.GetAllWithChildrenAndFilter(y => names.Contains(y.Name), x => x.Price).ToList();
            var mappedItems = _mapper.Map<List<Item>, List<ItemDTO>>(items);
            return mappedItems;
        }

        private ItemDTO ProcessNameLeagueGrouping(IGrouping<string, ItemDTO> groupings)
        {
            ItemDTO result = groupings.First();
            result.Occurances = groupings.Count();
            var currencyGroupings = groupings.GroupBy(x => x.Price.CurrencyType).OrderByDescending(x => x.Count());
            CurrencyType primaryCurrency = currencyGroupings.First().Key;
            foreach (var cG in currencyGroupings)
            {
                List<PriceDTO> prices = new List<PriceDTO>();
                foreach (ItemDTO i in cG)
                {
                    prices.Add(i.Price);
                }
                CalculatePriceRelatedProperties(result, primaryCurrency, prices);
            }
            return result;
        }

        private void CalculatePriceRelatedProperties(ItemDTO model, CurrencyType primaryCurrency, List<PriceDTO> prices)
        {
            var averaged = CalculateAveragePrice(prices);
            averaged.IconLink = ParsingTable.enumCurrencyToIconUri[averaged.CurrencyType];
            if (averaged.CurrencyType == primaryCurrency)
            {
                model.Price = averaged;
                var oldPrices = prices.Where(x => DateTime.Now.AddDays(-7) > x.DateCreated).ToList();
                if (oldPrices.Count != 0)
                {
                    var averagedOld = CalculateAveragePrice(oldPrices);
                    model.SevenDaysChange = CalculateChange(averagedOld.Ammount, model.Price.Ammount);
                }
            }
            else
                model.OtherCurrencyPrices.Add(averaged);
        }

        private PriceDTO CalculateAveragePrice(List<PriceDTO> prices)
        {
            int divider = 0;
            double ammount = 0;
            foreach (PriceDTO p in prices)
            {
                divider++;
                ammount += p.Ammount;
            }
            PriceDTO result = new PriceDTO
            {
                CurrencyType = prices.First().CurrencyType,
                Ammount = Math.Round(ammount / divider)
            };
            return result;
        }
        private double CalculateChange(double previous, double current)
        {
            var result = (current - previous) / Math.Abs(previous);
            return Math.Round(result);
        }
    }
}
