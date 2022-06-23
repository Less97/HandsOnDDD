using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public record UserId
    {
        private Guid _value;
        public UserId(Guid value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");
            }
            _value = value;
        }

        public static implicit operator Guid(UserId id) => id._value;
    }
}
