using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    public class TrieWithOneChild : ITrie 
    {
        private bool _wordEndsHere;
        private char _letter;
        private ITrie _child;

        public TrieWithOneChild(string s, bool wordHere)
        {
            if (s.Length <= 0)
            {
                throw new Exception("This trie should have a child");
            }
            if (Char.IsUpper(s[0]))
            {
                throw new Exception();
            }

            _letter = s[0];
            _wordEndsHere = wordHere;
            _child = new TrieWithNoChildren();
            _child = _child.Add(s.Substring(1));
        }

        public ITrie Add(string s)
        {
            if (s.Length == 0)
            {
                _wordEndsHere = true;
                return this;
            }
            else if (s[0] == _letter)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _wordEndsHere, _letter, _child);
            }
            
        }

        public bool Contains(String s)
        {
            if (s.Length == 0)
            {
                return _wordEndsHere;
            }
            else if (s[0] == _letter)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }

    }
}
