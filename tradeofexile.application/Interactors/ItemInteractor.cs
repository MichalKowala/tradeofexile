using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.infrastructure;
using tradeofexile.models.Items;

namespace tradeofexile.application.Interactors
{
    public class ItemInteractor : IItemInteractor
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<Price> _priceRepository;
        private readonly IPricer _pricer;
        private readonly IParser _parser;
        private readonly IItemExtensions _itemExtensions;
        public ItemInteractor(IBaseRepository<Item> itemRepository, IBaseRepository<Price> priceRepository, IPricer pricer, IParser parser, IItemExtensions itemExtensions)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _pricer = pricer;
            _parser = parser;
            _itemExtensions = itemExtensions;
        }
        public List<Item> GetPricedUniquesByItemCategory(ItemCategory itemCategory)
        {
            var names = _itemExtensions.GetNamesOfUniquesByItemCategory(itemCategory);
            var items = _itemRepository.GetAll().ToList().Where(x => names.Contains(x.Name)).ToList();
            items = AppendPricesToItems(items);
            items = StackDuplicateItems(items);
            throw new NotImplementedException();
        }
        public  List<Item> StackDuplicateItems(List<Item> items)
        {
            List<string> checkedNames = new List<string>();
            List<Item> stackedItems = new List<Item>();
            foreach (Item i in items)
            {
                List<Item> stack = new List<Item>();
                if (!checkedNames.Contains(i.Name))
                {
                    stack = items.Where(x => x.Name == i.Name).ToList();
                    checkedNames.Add(i.Name);
                    List<Price> prices = new List<Price>();
                    foreach (Item stackItem in stack)
                    {
                        if (stackItem.Price != null)
                            prices.Add(stackItem.Price);
                    }
                    Item stackedItem = stack.First();
                    stackedItem.Price = GetAveragedPrice(prices);
                    stackedItems.Add(stackedItem);
                }
            }
            return stackedItems;
        }
        public  Price GetAveragedPrice(List<Price> pricesToAverage, CurrencyType targetCurrency = CurrencyType.ChaosOrb)
        {
            double ammount = 0;
            int divider = 0;
            foreach (Price price in pricesToAverage)
            {
                if (price.CurrencyType != targetCurrency)
                {
                    Price p = _pricer.GetRate(targetCurrency, price.CurrencyType);
                    ammount += p.Ammount;
                    divider++;
                }
                else
                {
                    ammount += price.Ammount;
                    divider++;
                }
            }
            return new Price(ammount / divider, targetCurrency);
        }
        private List<Item> AppendPricesToItems(List<Item> items)
        {
            List<Item> itemsWithPrice = new List<Item>();
            List<Price> prices = _priceRepository.GetAll().ToList();
            foreach (Item i in items)
            {
                if (prices.Any(x => x.ItemId == i.Id))
                {
                    i.Price = prices.Where(x => x.ItemId == i.Id).First();
                }
                else
                {
                    i.Price = null;
                }
                itemsWithPrice.Add(i);
            }
            return itemsWithPrice;
        }
    }
}
