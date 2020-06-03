using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Core.Exceptions
{
    public class BoardNotCreatedException : Exception
    {
        public BoardNotCreatedException(string message)
            : base(message)
        {

        }
    }
}
