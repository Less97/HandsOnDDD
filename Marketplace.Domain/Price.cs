﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public record Price : Money
    {
        public Price(decimal amount,string currencyCode,ICurrencyLookup lookup) : base(amount,currencyCode,lookup)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Price cannot be negative", nameof(amount));
            }
        }

      

    }
}