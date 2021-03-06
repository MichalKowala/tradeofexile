﻿using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;

namespace tradeofexile.application.Abstraction
{
    public interface IApiItemQuerier
    {
        public string GetParametriziedGamepediaCallUrl(GamepediaItemClass itemClass, ItemRarity itemRarity, ResponseFormat responseFormat);
    }
}
