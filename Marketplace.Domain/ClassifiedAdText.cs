using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAdText
    {
        private string _adText;
        
        public ClassifiedAdText(string adText)
        {
            _adText = adText;
        }

        public static ClassifiedAdText FromString(string text) => new(text);

        public static implicit operator String(ClassifiedAdText text) => text._adText;
    }
}
