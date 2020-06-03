using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Core.Exceptions
{
    public class InvalidBoardSizeException : Exception
    {
        public InvalidBoardSizeException(string message)
            : base(message)
        {

        }
    }
}
