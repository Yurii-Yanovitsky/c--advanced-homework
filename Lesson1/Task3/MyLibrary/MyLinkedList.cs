using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.MyLibrary
{
    class MyLinkedList<TValue> : IEnumerable<TValue>
    {
        private Node _head;
        private Node _tail;

        public MyLinkedList()
        {
            _head = _tail = null;
        }

        public Node FirstNode => _head;
        public Node LastNode => _tail;

        public void AddLast(TValue value)
        {
            var node = new Node(value, null);

            if (_head == null && _tail == null)
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
        }
        public bool Any(Func<TValue, bool> condition)
        {
            var node = _head;
            while (node != null)
            {
                if (condition(node.Value))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        public TValue FirstOrDefault(Func<TValue, bool> condition)
        {
            var node = _head;
            while (node != null)
            {
                if (condition(node.Value))
                {
                    return node.Value;
                }
                node = node.Next;
            }
            return default;
        }
        public void ReplaseFirst(Func<TValue, bool> condition, TValue entry)
        {
            var node = _head;
            while (node != null)
            {
                if (condition(node.Value))
                {
                    node.Value = entry;
                }
                node = node.Next;
            }
        }

        public void AddAfter(Node node, TValue citizen)
        {
            var currentNode = node;
            var newNode = new Node(citizen, currentNode.Next);
            currentNode.Next = newNode;
        }

        public void AddBefore(Node node, TValue citizen)
        {
            var currentNode = node;
            var newNode = new Node(citizen, currentNode);

            if (currentNode != _head)
            {
                var previousNode = _head;
                while (previousNode.Next != node)
                {
                    previousNode = previousNode.Next;
                }
                previousNode.Next = newNode;
            }
            else
            {
                _head = newNode;
            }
        }

        public void RemoveFirst()
        {
            var node = _head?.Next;
            _head = node;
        }

        public void Remove(TValue value)
        {

            if (!_head.Value.Equals(value))
            {
                var previousNode = _head;
                while (!previousNode.Next.Value.Equals(value))
                {
                    previousNode = previousNode.Next;
                }
                previousNode.Next = previousNode.Next.Next;
            }
            else if (_head.Value.Equals(value))
            {
                _head = _head.Next;
            }

        }

        public void Clear()
        {
            _head = null;
        }

        // Реализация блока итератора для перебора бакета при помощи foreach
        public IEnumerator<TValue> GetEnumerator()
        {
            var node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Node
        {
            public Node(TValue value, Node next)
            {
                Value = value;
                Next = next;
            }
            public TValue Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
