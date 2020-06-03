using Ozow.TextSort.Core;
using System;

namespace Ozow.TextSort.CosnoleHost
{
    class Program
    {

        static void Main(string[] args)
        {

            var input = args[0];
            var sortedString = new CustomTextSort().Sort(input);
            Console.WriteLine(sortedString);
        }
    }
}
