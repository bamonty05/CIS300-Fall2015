/* Board.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Nim
{
    /// <summary>
    /// An immutable representation of a Nim board position.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The number of stones on each pile.
        /// </summary>
        private int[] _piles;

        /// <summary>
        /// The limit for each pile.
        /// </summary>
        private int[] _limits;

        /// <summary>
        /// Gets the number of piles.
        /// </summary>
        public int NumberOfPiles
        {
            get
            {
                return _piles.Length;
            }
        }
        private int _hash;
        private bool _hasHash;

        /// <summary>
        /// Constructs a new Board.
        /// </summary>
        /// <param name="piles">The number of stones on each pile.</param>
        /// <param name="limits">The limit for each pile.</param>
        public Board(int[] piles, int[] limits)
        {
            if (piles.Length != limits.Length)
            {
                throw new ArgumentException();
            }
            _piles = new int[piles.Length];
            piles.CopyTo(_piles, 0);
            _limits = new int[limits.Length];
            limits.CopyTo(_limits, 0);
        }

        /// <summary>
        /// Gets the result of making the given play from this board position.
        /// </summary>
        /// <param name="p">The play to make.</param>
        /// <returns>The resulting board position.</returns>
        public Board MakePlay(Play p)
        {
            if (p.Pile > _piles.Length || p.Number > _limits[p.Pile])
            {
                throw new ArgumentException();
            }
            Board b = new Board(_piles, _limits);
            b._piles[p.Pile] -= p.Number;
            b._limits[p.Pile] = Math.Min(b._piles[p.Pile], 2 * p.Number);
            return b;
        }

        /// <summary>
        /// Gets the number of stones on the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The number of stones on the given pile.</returns>
        public int GetValue(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _piles[pile];
        }

        /// <summary>
        /// Gets the limit for the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The limit for the given pile.</returns>
        public int GetLimit(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _limits[pile];
        }

        /// <summary>
        /// Determines whether the given board positions are equal.
        /// </summary>
        /// <param name="x">One board position.</param>
        /// <param name="y">The other board position.</param>
        /// <returns></returns>
        public static bool operator ==(Board x, Board y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._piles.Length != y._piles.Length)
                {
                    return false;
                }
                for (int i = 0; i < x._piles.Length; i++)
                {
                    if (x._piles[i] != y._piles[i] || x._limits[i] != y._limits[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Determines whether the given board positions are different.
        /// </summary>
        /// <param name="x">One board position.</param>
        /// <param name="y">The other board positoin.</param>
        /// <returns></returns>
        public static bool operator !=(Board x, Board y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether the given object is equal to this board position.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether the given object is equal to this board position.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Board)
            {
                return this == (Board)obj;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            //throw new NotImplementedException();
            if (_hasHash)
            {
                return _hash;
            }
            else
            {
                unchecked
                {
                    int code = _piles.Length;

                    for (int i = 0; i < _piles.Length; i++)
                    {
                        code *= 37;
                        code += _piles[i];
                        code *= 37;
                        code += _limits[i];
                    }
                    _hasHash = true;
                    _hash = code;
                    return _hash;
                }
            }
        }
    }
}
