/* Board.cs
 * Author: Jacob Dokos
 * Code: 48 51 43 46
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
            Array.Copy(piles, _piles, piles.Length);
            _limits = new int[limits.Length];
            Array.Copy(limits, _limits, limits.Length);
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

        public static bool operator==(Board x, Board y)
        {
            if (Equals(x, null))
            {
                if (Equals(y, null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (Equals(y, null))
            {
                return false;
            }
            if (x._limits.Length == y._limits.Length && x._piles.Length == y._piles.Length)
            {
                for (int i = 0; i < x._piles.Length; i++)
                {
                    if (x._piles[i] != y._piles[i] || x._piles[i] != y._piles[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(Board p1, Board p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Board)
            {
                Board p = (Board)obj;
                return (this == p);
            }
            else
            {
                return false;
            }
        }
    }
}
