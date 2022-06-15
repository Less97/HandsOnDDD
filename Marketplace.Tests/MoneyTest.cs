using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Domain;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        private static readonly ICurrencyLookup _currencyLookup = new FakeCurrencyLookup();

        [Fact]
        public void Money_objects_with_the_same_amount_should_be_equal()
        {
            var firstAmount = new Money(5,"EUR", _currencyLookup);
            var secondAmount = new Money(5,"EUR", _currencyLookup);
            Assert.Equal(firstAmount,secondAmount);
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = new Money(1, "EUR", _currencyLookup);
            var coin2 = new Money(2, "EUR", _currencyLookup);
            var coin3 = new Money(2, "EUR", _currencyLookup);
            var banknote = new Money(5, "EUR", _currencyLookup);
            Assert.Equal(banknote,coin1 + coin2 + coin3);
        }
    }
}
