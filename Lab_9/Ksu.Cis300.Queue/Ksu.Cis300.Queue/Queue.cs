using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Queue
{
    public class Queue<T>
    {
        private int _front = 0; 
        private T[] _list = new T[5]; 
        private int _size = 0;
        
        
        public int Count
        {
            get { return _size; }


        }


        public void Enqueue(T x)
        {
            if (_size == _list.Length)
            {
                T[] bigger = new T[_list.Length * 2];
                Array.Copy(_list, _front, bigger, 0, _list.Length - _front);
                Array.Copy(_list, 0, bigger, _list.Length - _front, _front);
                _front = 0;
                _list = bigger;
            }
            _list[(_front + _size) % _list.Length] = x;
            _size++;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            return _list[_front];
        }

        public T Dequeue()
        {
            T elem = Peek();
            _list[_front] = default(T);
            _front = (_front + 1) % _list.Length;
            _size--;

            return elem;
        }

    }
}
