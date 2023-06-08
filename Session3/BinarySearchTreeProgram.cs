using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MentorshipProgram.Session3
{
    [TestClass]
    public class BinarySearchTreeProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bst = new BinaryTree();
            bst.Insert(10);
            bst.Insert(11);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(20);
            bst.Insert(50);
            bst.BFS();
            bst.DFS();
        }

        public class BinaryTree
        {
            private class Node
            {
                public int value;
                public Node left;
                public Node right;

                public Node(int value)
                {
                    this.value = value;
                    this.left = null;
                    this.right = null;
                }
            }

            private Node root;

            public BinaryTree()
            {
                root = null;
            }

            public void Insert(int value)
            {
                root = InsertNode(root, value);
            }

            private Node InsertNode(Node current, int value)
            {
                if (current == null)
                {
                    return new Node(value);
                }
                else if (value < current.value)
                {
                    current.left = InsertNode(current.left, value);
                }
                else
                {
                    current.right = InsertNode(current.right, value);
                }

                return current;
            }

            /// <summary>
            /// visualization of binary tree
            /// https://www.cs.usfca.edu/~galles/visualization/BST.html
            /// </summary>

            public void BFS()
            {
                Console.WriteLine("***BFS of Binary Tree***");
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);
                while (q.Count > 0)
                {
                    Node currentNode = q.Dequeue();
                    Console.WriteLine(currentNode.value);
                    if (currentNode.left != null) q.Enqueue(currentNode.left);
                    if (currentNode.right != null) q.Enqueue(currentNode.right);
                }
            }

            public void DFS()
            {
                Console.WriteLine("***DFS of Binary Tree***");
                Node currentNode = root;
                DFSBinaryTree(currentNode);
            }

            private void DFSBinaryTree(Node root)
            {
                Console.WriteLine(root.value);
                if (root.left != null) DFSBinaryTree(root.left);
                if (root.right != null) DFSBinaryTree(root.right);
                return;
            }
        }


    }
}

