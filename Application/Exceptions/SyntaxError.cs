using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class SyntaxError : Exception
    {
        public SyntaxError(string message) : base(message)
        {
        }

        public SyntaxError(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
