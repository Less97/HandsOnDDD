using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Domain;

namespace Marketplace.Tests
{
    public class FakeCurrencyLookup : ICurrencyLookup
    {
        public static readonly IEnumerable<CurrencyDetails> _currencies = new[]
        {
            new CurrencyDetails("EUR", true, 2),
            new CurrencyDetails("USD", true, 2),
            new CurrencyDetails("JPY", true, 2),
            new CurrencyDetails("DEM", false, 2),
        };

        public CurrencyDetails FindCurrency(string currencyCode)
        {
            var currency = _currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
            return currency ?? CurrencyDetails.None;
        }
    }
}
