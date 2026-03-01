using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class MyStack<T>
    {
        List<T> _items = new List<T>();

        public void Push(T Item) { _items.Add(Item); }

        public T Pop()
        {
            if (_items.Count == 0) throw new Exception("Stack is empty – cannot Pop");
            T top = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            return top;
        }

        public T Peek()
        {
            if (_items.Count == 0) throw new Exception("Stack is empty – cannot Peek");
            return _items[_items.Count - 1];
        }

        public int Count => _items.Count;

    }
}
