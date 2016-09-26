/* TrieWithNoChildren.cs
 * Author: Jacob Dokos
 * Code: 86 31 71 43
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// A single trie node having no chldren.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        private bool _isEmpty;

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s.Length == 0)
            {
                return _isEmpty;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s.Length <= 0)
            {
                _isEmpty = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _isEmpty); 
            }
        }
    }
}
