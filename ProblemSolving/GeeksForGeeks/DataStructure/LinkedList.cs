using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.DataStructure
{
    /// <summary>
    /// Tow-way Linked List Implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node Prev;
            public Node Next;
            public T Value;

            public Node(T value) : this(value, null, null) { }

            public Node(T value, Node prev, Node next)
            {
                Value = value;
                Prev = prev;
                Next = next;
            }
        }

        private Node _head;
        private Node _current;
        private Node _tail;

        public int Size { get; private set; }

        public Node InsertFront(T value)
        {
            var node = new Node(value);
            Size++;

            if (_head == null)
            {

                _head = node;
                _current = node;
                _tail = node;

                return _head;
            }

            _head.Prev = node;
            node.Next = _head;
            _head = node;

            return _head;
        }

        public Node InsertTail(T value)
        {
            var node = new Node(value);
            Size++;

            if (_head == null)
            {
                _head = node;
                _current = node;
                _tail = node;

                return _head;
            }

            node.Prev = _tail;
            _tail.Next = node;
            _tail = node;

            return _head;
        }

        public Node InsertAfter(T value)
        {
            var node = new Node(value);

            if (_head == null)
            {
                _head = node;
                _current = node;
                _tail = node;
                Size++;

                return _head;
            }

            Node temp = _head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    if (temp == _tail)
                    {
                        InsertTail(value);
                        return _head;
                    }

                    node.Next = temp.Next;
                    node.Prev = temp;
                    temp.Next.Prev = node;
                    temp.Next = node;
                    Size++;

                    return _head;
                }

                temp = temp.Next;
            }

            InsertTail(value);

            return _head;
        }

        public Node DeteteFront()
        {
            if (Size == 0)
                throw new OverflowException("Linked List is empty");

            Node temp = _head;
            if (Size == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
            }
            Size--;

            return temp;
        }

        public Node DeleteTail()
        {
            if (Size == 0)
                throw new OverflowException("Linked List is empty");

            Node temp = _tail;
            if (Size == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = _tail.Prev;
                _tail.Next = null;
            }
            Size--;

            return temp;
        }

        public Node Delete(T value)
        {
            if (Size == 0)
                throw new OverflowException("Linked List is empty");

            Node temp = _head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    if (temp == _head || temp == _tail)
                    {
                        if (temp == _head)//match with head
                        {
                            _head = temp.Next;
                        }
                        if (temp == _tail)//match with Tail 
                        {
                            _tail = temp.Prev;
                        }
                    }
                    else
                    {
                        temp.Prev.Next = temp.Next;
                        temp.Next.Prev = temp.Prev;
                    }

                    Size--;
                }

                temp = temp.Next;
            }

            return temp;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Size = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Size);
            Node temp = _head;
            while(temp != null)
            {
                sb.Append(temp.Value + " ");
                temp = temp.Next;
            }

            return sb.ToString().Trim(); 
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node temp = _head;
            while (temp != null)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
