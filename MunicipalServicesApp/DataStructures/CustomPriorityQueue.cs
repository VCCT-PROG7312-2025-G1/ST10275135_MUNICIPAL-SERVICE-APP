using System;

namespace MunicipalServicesApp.DataStructures
{
     
    internal class PriorityNode<T>
    {
        public T Item;
        public int Priority;
        public PriorityNode<T> Next;
        public PriorityNode(T item, int priority) { Item = item; Priority = priority; Next = null; }
    }

    public class CustomPriorityQueue<T>
    {
        private PriorityNode<T> head;
        public CustomPriorityQueue() { head = null; }

        public void Enqueue(T item, int priority)
        {
            var node = new PriorityNode<T>(item, priority);
            if (head == null || priority > head.Priority)
            {
                node.Next = head;
                head = node;
                return;
            }
            var cur = head;
            while (cur.Next != null && cur.Next.Priority >= priority) cur = cur.Next;
            node.Next = cur.Next;
            cur.Next = node;
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException("Priority queue empty");
            var v = head.Item;
            head = head.Next;
            return v;
        }

        public bool IsEmpty => head == null;
    }
}
