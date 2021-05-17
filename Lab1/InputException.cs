using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class InputException : Exception
    {
        public InputException(string message) : base(message)
        {

        }
    }
}
