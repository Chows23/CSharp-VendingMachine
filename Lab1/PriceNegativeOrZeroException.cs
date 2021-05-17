using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class PriceNegativeOrZeroException : Exception
    {
        public PriceNegativeOrZeroException(string message) : base(message)
        {

        }
    }
}
