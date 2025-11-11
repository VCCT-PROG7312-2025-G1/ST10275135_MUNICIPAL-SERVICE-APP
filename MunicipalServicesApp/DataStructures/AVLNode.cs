using System;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    
    public class AVLNode
    {
        public ServiceRequest Data;
        public AVLNode Left;
        public AVLNode Right;
        public int Height;

        public AVLNode(ServiceRequest data)
        {
            Data = data;
            Height = 1;
        }
    }

    public class AVLTree
    {
        public AVLNode Root;

       
        private int Height(AVLNode node) => node?.Height ?? 0;

        private int GetBalance(AVLNode node) => node == null ? 0 : Height(node.Left) - Height(node.Right);


        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

    
        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public AVLNode Insert(AVLNode node, ServiceRequest data)
        {
            if (node == null) return new AVLNode(data);

            if (data.DateSubmitted < node.Data.DateSubmitted)
                node.Left = Insert(node.Left, data);
            else if (data.DateSubmitted > node.Data.DateSubmitted)
                node.Right = Insert(node.Right, data);
            else
                return node; 

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

          
            if (balance > 1 && data.DateSubmitted < node.Left.Data.DateSubmitted)
                return RightRotate(node);

      
            if (balance < -1 && data.DateSubmitted > node.Right.Data.DateSubmitted)
                return LeftRotate(node);

            if (balance > 1 && data.DateSubmitted > node.Left.Data.DateSubmitted)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && data.DateSubmitted < node.Right.Data.DateSubmitted)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public void Insert(ServiceRequest data)
        {
            Root = Insert(Root, data);
        }

     
        public void InOrderTraversal(AVLNode node, System.Collections.Generic.List<ServiceRequest> list)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, list);
            list.Add(node.Data);
            InOrderTraversal(node.Right, list);
        }

        public System.Collections.Generic.List<ServiceRequest> GetSortedList()
        {
            var list = new System.Collections.Generic.List<ServiceRequest>();
            InOrderTraversal(Root, list);
            return list;
        }
    }
}
