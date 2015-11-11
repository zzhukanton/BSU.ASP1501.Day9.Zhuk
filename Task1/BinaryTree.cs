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
