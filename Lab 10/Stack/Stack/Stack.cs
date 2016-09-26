 /*Stack.cs
 * Author: Jacob Dokos
   Completion: 24 93 85 13
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Stack
{
    public class Stack<T>
    {
        private LinkedListCell<T> _front = null; 
        private int _size = 0;

        public int Count
        {
            get 
            {
                return _size;
            }
        }

        public void Push(T x)
        {
            LinkedListCell<T> newCell = new LinkedListCell<T>();
            newCell.Data = x;
            newCell.Next = _front;
            _front = newCell;
            _size++;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException(); 
            }
            return _front.Data;
        }
        public T Pop()
        {
            T temp = Peek();
            _front = _front.Next;
            _size--;
            return temp;

        }

    }
}
