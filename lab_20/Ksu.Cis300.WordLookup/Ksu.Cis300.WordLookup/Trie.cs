/* Trie.cs
 * Author: jacob dokos
 * code 70 77 14 96
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// A single node of a trie.
    /// </summary>
    public class Trie
    {
        private bool _wordEndsHere = false;
        private Trie[] _children = new Trie[26];
        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s.Length == 0)
            {
                return _wordEndsHere;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                return false;
            }
            else
            {
                int index = s[0] - 'a';
                if (_children[index] == null)
                {
                    return false;
                }
                else
                {
                    string rest = s.Substring(1);
                    return _children[index].Contains(rest);
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public void Add(string s)
        {
            if (s.Length == 0)
            {
                 _wordEndsHere = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int index = s[0] - 'a';
                if (_children[index] == null)
                {
                    _children[index] = new Trie();
                }
                string rest = s.Substring(1);
                _children[index].Add(rest);
            }
        }
    }
}
