using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string message) : base(message)
        {
        }

        public NotFound(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
