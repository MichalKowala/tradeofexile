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
            var nameEntries = _namesRepository.GetAll(x => x.ItemCategory == itemCategory).ToList();
            var names = new List<string>();
            foreach (UniqueNameEntry entry in nameEntries)
            {
                names.Add(entry.Name);
            }
            var items = _itemRepository.GetAll(x => x.Price, y => names.Contains(y.Name)).ToList();
            return items;
        }
    }
}
