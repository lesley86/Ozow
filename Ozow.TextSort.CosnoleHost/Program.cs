using Ozow.TextSort.Core;
using System;

namespace Ozow.TextSort.CosnoleHost
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the string you wish to sort.");
            var input = Console.ReadLine();
            var sortedString = new CustomTextSort().Sort(input);
            Console.WriteLine(sortedString);
        }
    }
}
