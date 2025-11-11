using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    // MinHeap where "smaller" (earlier DateSubmitted) => higher priority
    public class MinHeap
    {
        private List<ServiceRequest> heap = new List<ServiceRequest>();

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        private int Compare(ServiceRequest a, ServiceRequest b)
        {
            // earlier date = smaller
            return a.DateSubmitted.CompareTo(b.DateSubmitted);
        }

        public void Insert(ServiceRequest r)
        {
            heap.Add(r);
            int i = heap.Count - 1;
            while (i > 0 && Compare(heap[i], heap[Parent(i)]) < 0)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public ServiceRequest ExtractMin()
        {
            if (heap.Count == 0) return null;
            var root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Heapify(0);
            return root;
        }

        private void Heapify(int i)
        {
            int l = Left(i), r = Right(i), smallest = i;
            if (l < heap.Count && Compare(heap[l], heap[smallest]) < 0) smallest = l;
            if (r < heap.Count && Compare(heap[r], heap[smallest]) < 0) smallest = r;
            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = heap[i];
            heap[i] = heap[j];
            heap[j] = tmp;
        }

        public int Count => heap.Count;

        public List<ServiceRequest> GetAllSortedByPriority()
        {
            var clone = new MinHeap();
            foreach (var r in heap) clone.Insert(r);

            var result = new List<ServiceRequest>();
            ServiceRequest next;
            while ((next = clone.ExtractMin()) != null)
                result.Add(next);
            return result;
        }
    }
}
