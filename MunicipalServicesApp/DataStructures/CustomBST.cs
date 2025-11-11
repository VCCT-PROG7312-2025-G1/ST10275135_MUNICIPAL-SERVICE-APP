using System;
using System.Collections;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    internal class BSTNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;
        public BSTNode<TKey, TValue> Left, Right;
        public BSTNode(TKey k, TValue v) { Key = k; Value = v; Left = Right = null; }
    }

    public class CustomBST<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private BSTNode<TKey, TValue> root;

        public void Insert(TKey key, TValue value)
        {
            root = InsertInternal(root, key, value);
        }

        private BSTNode<TKey, TValue> InsertInternal(BSTNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null) return new BSTNode<TKey, TValue>(key, value);
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) node.Left = InsertInternal(node.Left, key, value);
            else if (cmp > 0) node.Right = InsertInternal(node.Right, key, value);
            else node.Value = value; 
            return node;
        }

        public TValue Find(TKey key)
        {
            var cur = root;
            while (cur != null)
            {
                int cmp = key.CompareTo(cur.Key);
                if (cmp == 0) return cur.Value;
                cur = cmp < 0 ? cur.Left : cur.Right;
            }
            return default(TValue);
        }

        public bool TryFind(TKey key, out TValue value)
        {
            value = Find(key);
            if (value == null) return false;
            return true;
        }

        // In-order traversal to enumerate sorted by key
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Traverse(root).GetEnumerator();
        }

        private IEnumerable<KeyValuePair<TKey, TValue>> Traverse(BSTNode<TKey, TValue> n)
        {
            if (n == null) yield break;
            foreach (var x in Traverse(n.Left)) yield return x;
            yield return new KeyValuePair<TKey, TValue>(n.Key, n.Value);
            foreach (var x in Traverse(n.Right)) yield return x;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
