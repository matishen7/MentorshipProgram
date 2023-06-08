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
            bst.Delete(9);
            bst.BFS();
            bst.Delete(10);
            bst.BFS();
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

            public void Delete(int value)
            {
                DeleteNode(root, value);
            }


            private Node DeleteNode(Node root, int value)
            {
                if (root == null)
                    return root; // Value not found, return the original root

                if (value < root.value)
                {
                    root.left = DeleteNode(root.left, value); // Value is in the left subtree
                }
                else if (value > root.value)
                {
                    root.right = DeleteNode(root.right, value); // Value is in the right subtree
                }
                else
                {
                    // Value found, perform deletion based on the scenarios
                    if (root.left == null)
                    {
                        return root.right; // Node has no left child, replace with the right child (or null)
                    }
                    else if (root.right == null)
                    {
                        return root.left; // Node has no right child, replace with the left child
                    }
                    else
                    {
                        // Node has two children, find the minimum value in the right subtree
                        Node minRight = FindMinimum(root.right);
                        root.value = minRight.value; // Replace the value of the current node with the minimum value
                        root.right = DeleteNode(root.right, minRight.value); // Recursively delete the duplicate value node
                    }
                }

                return root;
            }
            private Node FindMinimum(Node node)
            {
                while (node.left != null)
                {
                    node = node.left;
                }

                return node;
            }
        }
    }
}

