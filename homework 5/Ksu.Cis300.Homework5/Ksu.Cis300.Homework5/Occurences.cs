/* Occurences.cs
 * Author: Jacob Dokos
 */

using System;

namespace Ksu.Cis300.Homework5
{
    /// <summary>
    /// Gathers the amount occurences of a word in a file
    /// </summary>
    public class Occurences
    {
        private string _word; 
        private int[] _numberOccurences; //storing occurence of each word in a file size is equal to # of files to be processes

        /// <summary>
        /// Makes a new Occurence object.
        /// </summary>
        /// <param name="word">word that the object is counting the for</param>
        /// <param name="numberFiles">The total number of files that the object is counting for</param>
        public Occurences(string word, int numberFiles)
        {
            _word = word;
            _numberOccurences = new int[numberFiles];
        }

        /// <summary>
        /// Parameter to get the word variable
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }  
        }

        /// <summary>
        /// Returns the number of files in the object
        /// </summary>
        /// <returns></returns>
        public int getNumberOfFiles()
        {
            return _numberOccurences.Length;
        }

        /// <summary>
        /// Indexer to get the _numberOccurences variable
        /// </summary>
        /// <param name="k">which file to return the word occurences for</param>
        /// <returns>word occurences</returns>
        public int this[int k]
        {
            get
            {
                if (k >= _numberOccurences.Length || k < 0)
                {
                    throw new ArgumentException();
                }
                return _numberOccurences[k];
            }
        }

        /// <summary>
        /// Increments the occurences based on which file number is passed in
        /// </summary>
        /// <param name="k">File number</param>
        public void incrementOccurences(int k)
        {
            if (k >= _numberOccurences.Length)
            {
                throw new ArgumentException("Increment");
            }
            else
            {
                _numberOccurences[k]++;
            }
        }
    }
}
