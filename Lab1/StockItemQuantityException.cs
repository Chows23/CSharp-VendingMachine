using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class StockItemQuantityException : Exception
    {
        public StockItemQuantityException(string message) : base(message)
        {

        }
    }
}
