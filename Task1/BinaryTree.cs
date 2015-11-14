using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BinaryTree<T>: IEnumerable<T>
    {
        private Node root;
        private int count;
        private IComparer<T> comparer;

        public BinaryTree(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("Comparer object is null");
            this.comparer = comparer;
        }

        public BinaryTree(Comparison<T> comparator)
        {
            if (comparator == null)
                throw new ArgumentNullException("Comparision is null");
            comparer = Comparer<T>.Create(comparator);
        }

        public BinaryTree()
        {
            this.comparer = Comparer<T>.Default;
        }

        public int Count
        {
            get { return count; }
        }

        public IEnumerable<T> InOrder()
        {
            if (root != null)
                foreach (var value in root.InOrder())
                    yield return value;
        }

        public IEnumerable<T> PostOrder()
        {
            if (root != null)
                foreach (var value in root.PostOrder())
                    yield return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root != null)
                foreach (var value in root)
                    yield return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            Insert(value, ref root);
        }

        public bool Remove(T value)
        {
            return Delete(value, ref root);
        }

        private bool Delete(T value, ref Node node)
        {
            if (node == null)
                return false;

            int comp = comparer.Compare(node.data, value);
            if (comp < 0)
                return Delete(value, ref node.right);
            if (comp > 0)
                return Delete(value, ref node.left);

            DeleteNode(ref node);
            count--;
            return true;
        }

        private void DeleteNode(ref Node node)
        {
            if (node.left == null && node.right == null)
                node = null;
            else 
                if (node.left == null || node.right == null)
                    node = node.right ?? node.left;
                else
                {
                    if (node.right.left == null)
                    {
                        node.right.left = node.left;
                        node = node.right;
                    }
                    else
                    {
                        var next = node.right.left;
                        var paret = node.right;
                        while (next.left != null)
                        {
                            paret = next;
                            next = next.left;
                        }
                        paret.left = next.right;
                        next.right = node.right;
                        next.left = node.left;
                        node = next;
                }
            }
        }

        private void Insert(T value, ref Node node)
        {
            if (node == null)
            {
                node = new Node(value);
                count++;
                return;
            }

            int comp = comparer.Compare(value, node.data);
            if (comp == 0)
                return;
            if (comp < 0)
                Insert(value, ref node.left);
            else
                Insert(value, ref node.right);
        }

        private class Node : IEnumerable<T>
        {
            public Node right;
            public Node left;
            public T data;

            public Node(T data)
            {
                this.data = data;
                this.right = null;
                this.left = null;
            }

            public IEnumerable<T> InOrder()
            {     
                if (left != null)
                    foreach (var item in left.InOrder())
                        yield return item;

                yield return data;
                
                if (right != null)
                    foreach (var item in right.InOrder())
                        yield return item;
            }

            public IEnumerable<T> PostOrder()
            {
                if (left != null)
                    foreach (var item in left)
                        yield return item;

                if (right != null)
                    foreach (var item in right)
                        yield return item;
                
                yield return data;
            }

            public IEnumerator<T> GetEnumerator()
            {
                yield return data;

                if (left != null)
                    foreach (var item in left)
                        yield return item;

                if (right != null)
                    foreach (var item in right)
                        yield return item;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }


        }
    }
}
