using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class InputMoneyException : Exception
    {
        public InputMoneyException(string message) : base(message)
        {

        }
    }
}
