using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public record Money
    {
        private decimal Amount;
        private string CurrencyCode;

        private const string DefaultCurrency = "EUR";
        
        public Money(decimal amount,string currencyCode = DefaultCurrency)
        {
            if (decimal.Round(amount, 2) != amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot have more than 2 decimals");
            }

            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public Money Add(Money summand)
        {
            if (summand.CurrencyCode != CurrencyCode)
            {
                throw new CurrencyMismatchException("Cannot add amounts with different currencies");
            }

            return new (Amount + summand.Amount);
        }


        public Money Subtract(Money subtrahend) 
        {
            if (subtrahend.CurrencyCode != CurrencyCode)
            {
                throw new CurrencyMismatchException("Cannot subtract amounts with different currencies");
            }
            return new(Amount - subtrahend.Amount);
        }

        public static Money operator +(Money summand1, Money summand2) => new (summand1.Amount + summand2.Amount);
        public static Money operator -(Money minuend, Money subtrahend) => new (minuend.Amount - subtrahend.Amount);

        public static Money FromDecimal(decimal amount, string currencyCode = DefaultCurrency) => new(amount,currencyCode);
        public static Money FromString(string amount, string currencyCode = DefaultCurrency) => new(decimal.Parse(amount), currencyCode);


        public class CurrencyMismatchException : Exception
        {
            public CurrencyMismatchException(string message) : base(message)
            {

            }
        }
    }

}
