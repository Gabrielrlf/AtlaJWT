using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Exception
{
    public class UserException : ArgumentException
    {
        public UserException(string message) : base(message)
        {
        }
    }
}
