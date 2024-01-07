using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Exceptions.Id
{
    public class IdZeroAndNegativeException : Exception
    {
        public IdZeroAndNegativeException():base("Id 0 ve menfi ola bilmez")
        {
        }

        public IdZeroAndNegativeException(string? message) : base(message)
        {
        }
    }
}
