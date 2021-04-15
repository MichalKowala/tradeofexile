using System;
using System.Collections.Generic;
using System.Linq;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interactors
{
    public class ItemInteractor : IItemInteractor
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<UniqueNameEntry> _namesRepository;
        public ItemInteractor(IBaseRepository<Item> itemRepository, IBaseRepository<Price> priceRepository, IBaseRepository<UniqueNameEntry> namesRepository)
        {
            _itemRepository = itemRepository;
            _namesRepository = namesRepository;
        }
        public List<Item> GetPricedUniquesByItemCategory(ItemCategory itemCategory)
        {
            var nameEntries = _namesRepository.GetAll(x => x.ItemCategory == itemCategory).ToList();
            var names = new List<string>();
            foreach (UniqueNameEntry entry in nameEntries)
            {
                names.Add(entry.Name);
            }
            var items = _itemRepository.GetAll(x => x.Price, y => names.Contains(y.Name)).ToList();
            return items;
        }
        public Price CalculateAveragePrice(List<Price> prices)
        {
            int divider = 0;
            double ammount = 0;
            foreach (Price p in prices)
            {
                divider++;
                ammount += p.Ammount;
            }
            Price result = new Price
            {
                CurrencyType = prices.First().CurrencyType,
                Ammount = Math.Round(ammount / divider)
            };
            return result;
        }

        public double CalculateChange(double previous, double current)
        {
            var result = (current - previous) / Math.Abs(previous);
            return result;
        }
    }
}
