using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.infrastructure;
using tradeofexile.models.EntityItems;
using Microsoft.EntityFrameworkCore;
 
namespace tradeofexile.application.Interactors
{
    public class ItemInteractor : IItemInteractor
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<Price> _priceRepository;
        private readonly IBaseRepository<UniqueNameEntry> _namesRepository;
        private readonly IPricer _pricer;
        private readonly IGamepediaResponseHandler _gamepediaResponseHandler;
        public ItemInteractor(IBaseRepository<Item> itemRepository, IBaseRepository<Price> priceRepository, IPricer pricer, IGamepediaResponseHandler gamepediaResponseHandler, IBaseRepository<UniqueNameEntry> namesRepository)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _pricer = pricer;
            _gamepediaResponseHandler = gamepediaResponseHandler;
            _namesRepository = namesRepository;
        }
        public List<Item> GetPricedUniquesByItemCategory(ItemCategory itemCategory)
        {
            _gamepediaResponseHandler.UpdateUniqueNames();
             var nameEntries = _namesRepository.GetAll(x => x.ItemCategory == itemCategory).ToList();
            var names = new List<string>();
            foreach (UniqueNameEntry entry in nameEntries)
            {
                names.Add(entry.Name);
            }
            var itemss = _itemRepository.GetAll(x => names.Contains(x.Name)).Include(x => x.Price).ToList();
            var items = _itemRepository.GetAll(x => x.Price, y => names.Contains(y.Name)).ToList();
            return items;
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
       
    }
}
