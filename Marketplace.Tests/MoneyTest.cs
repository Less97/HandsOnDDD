using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Domain;
using Xunit;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        private static readonly ICurrencyLookup _currencyLookup = new FakeCurrencyLookup();

        [Fact]
        public void Two_of_the_same_amount_should_be_equal()
        {
            var firstAmount = new Money(5, "EUR", _currencyLookup);
            var secondAmount = new Money(5, "EUR", _currencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Two_of_the_same_amount_but_different_currencies_should_not_be_equal()
        {
            var firstAmount = new Money(5, "EUR", _currencyLookup);
            var secondAmount = new Money(5, "USD", _currencyLookup);
            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void FromString_and_FromDecimal_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
            var secondAmount = Money.FromString("5", "EUR", _currencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }
        [Fact]
        public void Money_objects_with_the_same_amount_should_be_equal()
        {
            var firstAmount = new Money(5, "EUR", _currencyLookup);
            var secondAmount = new Money(5, "EUR", _currencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Unused_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.FromDecimal(100, "DEM", _currencyLookup));
        }

        [Fact]
        public void Unknown_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.FromDecimal(100, "WHAT?", _currencyLookup));
        }

        [Fact]
        public void Throw_when_too_many_decimal_places()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Money.FromDecimal(100.123M, "EUR", _currencyLookup));
        }

        [Fact]
        public void Throws_on_adding_different_currencies()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
            var secondAmount = Money.FromDecimal(5, "USD", _currencyLookup);
            Assert.Throws<CurrencyMismatchException>(() => firstAmount + secondAmount);
        }

        [Fact]
        public void Throws_on_Subtracting_different_currencies()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
            var secondAmount = Money.FromDecimal(5, "USD", _currencyLookup);
            Assert.Throws<CurrencyMismatchException>(() => firstAmount - secondAmount);
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
