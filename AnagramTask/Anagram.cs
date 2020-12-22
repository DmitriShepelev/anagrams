using System;
using System.Collections.Generic;

namespace AnagramTask
{
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException($"The {nameof(sourceWord)} cannot be empty.");
            }

            this.Word = sourceWord.ToUpperInvariant();
        }

        public string Word { get; }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            var result = new List<string>();
            var soursWord = this.Word.ToCharArray();
            Array.Sort(soursWord);
            for (int i = 0; i < candidates.Length; i++)
            {
                if (this.Word.Length == candidates[i].Length &&
                    this.Word != candidates[i].ToUpperInvariant())
                {
                    var tmp = candidates[i].ToUpperInvariant().ToCharArray();
                    Array.Sort(tmp);
                    if (IsEqual(soursWord, tmp))
                    {
                        result.Add(candidates[i]);
                    }
                }
            }

            return result.ToArray();
        }

        private static bool IsEqual(char[] a, char[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
