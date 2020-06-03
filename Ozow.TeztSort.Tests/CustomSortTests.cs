using NUnit.Framework;
using Ozow.TextSort.Core;
using System;

namespace Ozow.TextSort.Tests
{
    [TestFixture]
    public class CustomSortTests
    {
        [Test]
        public void ShouldSortStringAlphabetically()
        {
            var stringSorter = new CustomTextSort();
            var result = stringSorter.Sort("Contrary to popular belief, the pink unicorn flies east.");
            var expected = "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy";
            for (int resultIndex = 0; resultIndex < result.Length; resultIndex++)
            {
                char.Equals(result[0], expected[0]);
            }
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfEmptyString()
        {
            var stringSorter = new CustomTextSort();
            Assert.Throws<ArgumentException>(() => stringSorter.Sort(""));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfNoLettersInString()
        {
            var stringSorter = new CustomTextSort();
            Assert.Throws<ArgumentException>(() => stringSorter.Sort("1231865465"));
        }
    }
}
