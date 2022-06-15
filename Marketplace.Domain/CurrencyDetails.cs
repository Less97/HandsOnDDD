using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public record CurrencyDetails(string CurrencyCode, bool InUse, int DecimalPlaces)
    {

        public static CurrencyDetails None = new CurrencyDetails("", false, 0);

    }
}
