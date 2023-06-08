using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Session3
{
    [TestClass]
    public class BinarySearchTreeProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bst = new BinarySearchTree();
            bst.Insert(10, null);
        }

        public class BinarySearchTree
        {
            public BinaryNode head;
            public BinarySearchTree()
            {
                head = null;
            }
            public BinarySearchTree(BinaryNode head)
            {
                this.head = head;
            }

            public void Insert(int val, BinaryNode node)
            {
                if (node == null)
                {
                    node = new BinaryNode(val);
                    this.head = node;
                }
                else if (val < node.value)
                {
                    if (node.left != null)
                        Insert(val, node.left);
                    else node.left = new BinaryNode(val);
                }
                else
                {
                    if (node.right != null)
                        Insert(val, node.right);
                    else node.right = new BinaryNode(val);
                }
            }
        }

        public class BinaryNode
        {
            public int value;
            public BinaryNode left;
            public BinaryNode right;

            public BinaryNode() { }
            public BinaryNode(int value) { this.value = value; }

            public BinaryNode(int value, BinaryNode left, BinaryNode right) : this(value)
            {
                this.left = left;
                this.right = right;
            }
        }

    }
}

