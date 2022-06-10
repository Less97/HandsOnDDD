using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAdId Id { get; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            _ownerId = ownerId;
            Id = id;
        }

        public void SetTitle(string title) => _title = title;
        public void SetText(string text) => _text = text;
        public void UpdatePrice(decimal price) => _price = price;


        public UserId _ownerId;
        private string _title;
        private string _text;
        private decimal _price;
    }
}
