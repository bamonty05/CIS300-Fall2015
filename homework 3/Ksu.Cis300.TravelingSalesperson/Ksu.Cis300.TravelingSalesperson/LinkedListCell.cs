using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TravelingSalesperson
{
    public class LinkedListCell<T>
    {
        private T _data; 
        LinkedListCell<T> _next;
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        public LinkedListCell<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
    }
}
