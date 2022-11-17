using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Doubly_Linked_List
{
    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(Node node)
        {
            Count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            else
            {
                Head.Previous = node;
                node.Next = Head;
                Head = node;
            }
        }

        public void AddFirst(int value)
        {
            AddFirst(new Node(value));
        }

        public void AddLast(Node node)
        {
            Count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
        }

        public void AddLast(int value)
        {
            AddLast(new Node(value));
        }

        public int RemoveFirst()
        {
            Count--;
            Node oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            oldHead.Next = null;

            return oldHead.Value;
        }

        public int RemoveLast()
        {
            Count--;
            Node oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            oldTail.Previous = null;

            return oldTail.Value;
        }

        public void ForEach(Action<int> callback)
        {
            Node node = Head;

            while (node != null)
            {
                callback(node.Value);
                node = node.Next;
            }
        }
        public void ForEachReverse(Action<int> callback)
        {
            Node node = Tail;
            while (node != null)
            {
                callback(node.Value);
                node = node.Previous;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            ForEach(n =>
            {
                array[index++] = n;
            });

            return array;
        }
    }
}
