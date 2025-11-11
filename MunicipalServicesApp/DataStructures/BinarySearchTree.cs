using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    public class BstNode
    {
        public ServiceRequest Data;
        public BstNode Left;
        public BstNode Right;
        public BstNode(ServiceRequest d) { Data = d; Left = Right = null; }
    }

    public class BinarySearchTree
    {
        private StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        public BstNode Root { get; private set; }

        public void Insert(ServiceRequest req)
        {
            Root = InsertRec(Root, req);
        }

        private BstNode InsertRec(BstNode node, ServiceRequest req)
        {
            if (node == null) return new BstNode(req);

            int cmp = comparer.Compare(req.Id, node.Data.Id);
            if (cmp < 0)
                node.Left = InsertRec(node.Left, req);
            else if (cmp > 0)
                node.Right = InsertRec(node.Right, req);
            else
            {
                // duplicate Id 
                node.Data = req;
            }
            return node;
        }

        public ServiceRequest Search(string id)
        {
            return SearchRec(Root, id);
        }

        private ServiceRequest SearchRec(BstNode node, string id)
        {
            if (node == null) return null;
            int cmp = comparer.Compare(id, node.Data.Id);
            if (cmp == 0) return node.Data;
            if (cmp < 0) return SearchRec(node.Left, id);
            return SearchRec(node.Right, id);
        }

        public List<ServiceRequest> InOrderTraversal()
        {
            var list = new List<ServiceRequest>();
            InOrder(Root, list);
            return list;
        }

        private void InOrder(BstNode node, List<ServiceRequest> list)
        {
            if (node == null) return;
            InOrder(node.Left, list);
            list.Add(node.Data);
            InOrder(node.Right, list);
        }
    }
}
