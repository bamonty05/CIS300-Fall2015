﻿/* Dictionary.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.Nim
{
    /// <summary>
    /// A dictionary implemented using a hash table.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public class Dictionary<TKey, TValue>
    {
        private const int _initialSize = 197;
        private int[] _tableSizes = 
{ 
    _initialSize, 397, 797, 1597, 3203, 6421, 12853, 25717, 51437, 102877,
    205759, 411527, 823117, 1646237, 3292489, 6584983, 13169977,
    26339969, 52679969, 105359939, 210719881, 421439783, 842879579,
    1685759167 
};
        private int _currentIndex = 0;
        private int _values = 0;

        /// <summary>
        /// The hash table storing the keys with their associated values.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>[] _table = new LinkedListCell<KeyValuePair<TKey, TValue>>[_initialSize];

        /// <summary>
        /// Verifies that the given key is non-null. If k is null, throws an ArgumentNullException.
        /// </summary>
        /// <param name="k">The key to check.</param>
        private void CheckKey(TKey k)
        {
            if (k == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets the table location in which the given key belongs.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <returns>The table location in which k belongs.</returns>
        private int GetLocation(TKey k)
        {
            return (k.GetHashCode() & 0x7fffffff) % _table.Length;
        }

        /// <summary>
        /// Finds the cell with the given key in the given linked list.
        /// </summary>
        /// <param name="k">The key to look for.</param>
        /// <param name="list">The beginning of the linked list to search.</param>
        /// <returns>The cell containing k, or null if there is no such cell.</returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>> list)
        {
            while (list != null)
            {
                if (list.Data.Key.Equals(k))
                {
                    return list;
                }
                list = list.Next;
            }
            return null;
        }

        /// <summary>
        /// Inserts the given cell at the beginning of the linked list at the given table location.
        /// </summary>
        /// <param name="cell">The cell to insert.</param>
        /// <param name="loc">The table location containing the linked list in which the cell is to be
        /// inserted.</param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _table[loc];
            _table[loc] = cell;

        }

        /// <summary>
        /// Inserts the given key and value into a new cell at the beginning of the linked list at the
        /// given table location.
        /// </summary>
        /// <param name="k">The key to insert.</param>
        /// <param name="v">The value to insert.</param>
        /// <param name="loc">The table location containing the linked list in which the given key and
        /// value are to be inserted.</param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = new LinkedListCell<KeyValuePair<TKey, TValue>>();
            cell.Data = new KeyValuePair<TKey, TValue>(k, v);
            Insert(cell, loc);
            _values++;

            if (_values > _table.Length)
            {
                if (_currentIndex < _table.Length - 1) //before wrong
                {
                    LinkedListCell<KeyValuePair<TKey, TValue>>[] oldTable = new LinkedListCell<KeyValuePair<TKey, TValue>>[_table.Length];
                    oldTable = _table;
                    _table = new LinkedListCell<KeyValuePair<TKey, TValue>>[_tableSizes[++_currentIndex]];
                    for (int i = 0; i < oldTable.Length; i++)
                    {

                        while (oldTable[i] != null)
                        {
                            LinkedListCell<KeyValuePair<TKey, TValue>> temp = oldTable[i];
                            oldTable[i] = oldTable[i].Next;

                            int location = GetLocation(temp.Data.Key);
                            Insert(temp, location);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tries to get the value associated with the given key. If k is null, throws an ArgumentNullException.
        /// </summary>
        /// <param name="k">The key to look for.</param>
        /// <param name="v">The value associated with k, or the default value for this type if k is not in the
        /// dictionary.</param>
        /// <returns>Whether the was found.</returns>
        public bool TryGetValue(TKey k, out TValue v)
        {
            CheckKey(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = GetCell(k, _table[GetLocation(k)]);
            if (cell == null)
            {
                v = default(TValue);
                return false;
            }
            else
            {
                v = cell.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// Associates the given value with the given key. If k is null, throws an ArgumentNullException.
        /// If k is already in the table, throws an ArgumentException.
        /// </summary>
        /// <param name="k">The key to add.</param>
        /// <param name="v">The value to associate with k.</param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            if (GetCell(k, _table[loc]) == null)
            {
                Insert(k, v, loc);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
