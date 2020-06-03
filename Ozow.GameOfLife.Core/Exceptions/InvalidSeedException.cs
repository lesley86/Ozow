using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Core.Exceptions
{
    public class InvalidSeedException : Exception
    {
        public InvalidSeedException(string message)
            : base(message)
        {

        }
    }
}
