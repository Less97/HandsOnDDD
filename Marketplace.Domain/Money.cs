using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain
{
    public record Money
    {
        public decimal Amount;
        public CurrencyDetails Currency;
        public static string DefaultCurrency = "EUR";

        public Money(decimal amount,string currencyCode,ICurrencyLookup currencyLookup)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentNullException(nameof(currencyCode), "Currency must be specified");
            }

            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
            {
                throw new ArgumentException($"Currency {currencyCode} is not valid");
            }

            if (decimal.Round(amount, 2) != amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot have more than 2 decimals");
            }

            Amount = amount;
            Currency = currency;
        }

        private Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money summand)
        {
            if (summand.Currency != Currency)
            {
                throw new CurrencyMismatchException("Cannot add amounts with different currencies");
            }

            return new (Amount + summand.Amount, Currency);
        }


        public Money Subtract(Money subtrahend) 
        {
            if (subtrahend.Currency != Currency)
            {
                throw new CurrencyMismatchException("Cannot subtract amounts with different currencies");
            }
            return new(Amount - subtrahend.Amount, Currency);
        }

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);
        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);

        public static Money FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new(amount, currency, currencyLookup);
        public static Money FromString(string amount, string currency,ICurrencyLookup currencyLookup) => new(decimal.Parse(amount), currency, currencyLookup);

    }

}
