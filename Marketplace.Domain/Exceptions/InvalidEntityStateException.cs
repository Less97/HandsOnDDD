using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Exceptions
{
    public class InvalidEntityStateException : Exception
    {

        public InvalidEntityStateException(object entity,string message) : base($"Entity {entity.GetType().Name} state change rejected, {message}")
        {}
    }
}
