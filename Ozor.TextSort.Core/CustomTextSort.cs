using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ozow.TextSort.Core
{
    public class CustomTextSort : ISortString
    {
        public string Sort(string stringToSort)
        {
            ValidateString(stringToSort, "The string is empty and cannot be sorted");
            var strippedOfNonTextCharacters = Regex.Replace(stringToSort, "[^a-zA-Z]", "").ToLower();
            ValidateString(strippedOfNonTextCharacters, "There are no alphabet letters within this string");
            var alphabetDictionary = SortValuesIntoDictionary(strippedOfNonTextCharacters);
            var result = string.Concat(alphabetDictionary.Where(y => y.Value > 0).Select(x => new string(x.Key, x.Value)));
            return result;
        }

        private static Dictionary<char, int> SortValuesIntoDictionary(string strippedOfNonTextCharacters)
        {
            var inputStringClone = strippedOfNonTextCharacters;
            var alphabetDictionary = CreateAlphabetDictionary();
            foreach (var character in strippedOfNonTextCharacters)
            {
                var occurencesOfChar = inputStringClone.Count(x => x == character);
                alphabetDictionary[character] = occurencesOfChar;
                inputStringClone.Replace(character.ToString(), string.Empty);
                if (inputStringClone.Length == 0)
                {
                    break;
                }
            }

            return alphabetDictionary;
        }

        private static void ValidateString(string stringToSort, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(stringToSort))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static Dictionary<char, int> CreateAlphabetDictionary()
        {
            return new Dictionary<char, int>
            {
                {'a', 0},
                {'b', 0},
                {'c', 0},
                {'d', 0},
                {'e', 0},
                {'f', 0},
                {'g', 0},
                {'h', 0},
                {'i', 0},
                {'j', 0},
                {'k', 0},
                {'l', 0},
                {'m', 0},
                {'n', 0},
                {'o', 0},
                {'p', 0},
                {'q', 0},
                {'r', 0},
                {'s', 0},
                {'t', 0},
                {'u', 0},
                {'v', 0},
                {'w', 0},
                {'x', 0},
                {'y', 0},
                {'z', 0},
            };
        }
    }
}
