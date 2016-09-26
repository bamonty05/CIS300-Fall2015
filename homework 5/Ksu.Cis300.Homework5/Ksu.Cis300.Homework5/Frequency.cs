/* Frequency.cs
 * Author: Jacob Dokos
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Homework5
{
    /// <summary>
    /// A class to hold the frequency of a word
    /// </summary>
    public struct Frequency
    {
        private string _word;
        private float[] _frequency; //frequency of the word in the file

        /// <summary>
        /// Makes a new frequency object with all variables filled
        /// </summary>
        /// <param name="occ">Occurence object that the frequency object gets the data from</param>
        /// <param name="words">Number of words in each file</param>
        public Frequency(Occurences occ, int[] words)
        {
            _word = occ.Word;

            if (words.Length != occ.getNumberOfFiles())
            {
                throw new ArgumentException();
            }
            _frequency = new float[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                _frequency[i] = (((float) occ[i]) / ((float) words[i]));
            }
            
        }

        /// <summary>
        /// Parameter to return the word variable
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }


        /// <summary>
        /// Indexer to get the _frequency variable
        /// </summary>
        /// <param name="k">which file to return the word frequency for</param>
        /// <returns>Word frequency</returns>
        public float this[int k]
        {
            get
            {
                if (k >= _frequency.Length || k < 0)
                {
                    throw new ArgumentException();
                }
                return _frequency[k];
            }
        }
    }
}
