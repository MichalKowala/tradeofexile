﻿using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models.EntityItems
{
    public class Price : BaseEntity
    {
        public double Ammount { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public Guid? ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public Price(double ammount, CurrencyType currencyType)
        {
            Ammount = ammount;
            CurrencyType = currencyType;
        }
        public Price()
        {

        }
       
    }
}
