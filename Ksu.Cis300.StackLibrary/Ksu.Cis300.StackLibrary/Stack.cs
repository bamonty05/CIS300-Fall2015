/* Stack.cs
 * Author: Jacob Dokos
   Completion: 59 89 35 91 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.StackLibrary
{
    /// <summary>
    /// Class for our implementation of a stack
    /// </summary>
    /// <typeparam name="T">T will represent the type of the elements that will be stored in the stack</typeparam>
    public class Stack<T>
    {
        private int _size = 0;
        private T[] _list = new T[5];
        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Push(T x)
        {
            if (_size >= _list.Length)
            {
                T[] bigger = new T[2 * _list.Length];
                Array.Copy(_list, bigger, _list.Length);
                _list = bigger;
            }
            _list[_size] = x;
            _size++;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException();
            }
            
                return (_list[_size - 1]);
            

        }
        public T Pop()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException();
            }

            T temp = Peek();
            _size--;
            

            return temp;
            

        }


}
}
