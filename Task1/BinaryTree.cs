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
                foreach (var val in root)
                    yield return val;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
