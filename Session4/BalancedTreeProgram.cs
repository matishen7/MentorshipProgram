using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorshipProgram.Session4
{
    [TestClass]
    public class BalancedTreeProgram
    {

        [TestMethod]
        public void BalancedTreeProgramTest()
        {
            var tree = new BinaryTree();
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(10);
            tree.Insert(11);
            tree.BFS();
        }

        public class BinaryTree
        {
            public class Node
            {
                public int value;
                public Node left;
                public Node right;
                public int height;

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

            public Node Insert(int value)
            {
                if (root == null)
                {
                    root = new Node(value);
                    return root;
                }

                if (value < root.value)
                    root.left = Insert(value);
                else if (value > root.value)
                    root.right = Insert(value);
                else return root;

                root.height = 1 + Math.Max(CalculateHeight(root.left), CalculateHeight(root.right));

                var balancedFactor = getBalancedFactor(root);

                if (balancedFactor > 1 && value < root.left.value)
                    return rightRotate(root);

                else if (balancedFactor < -1 && value > root.right.value)
                    return leftRotate(root);

                else if (balancedFactor > 1 && value > root.left.value)
                {
                    root.left = leftRotate(root.left);
                    return rightRotate(root);
                }

                else
                {
                    root.right = rightRotate(root.right);
                    return leftRotate(root);
                }

                return root;

            }

            private int CalculateHeight(Node root)
            {
                if (root == null)
                    return -1; // Empty tree has height -1

                int leftHeight = CalculateHeight(root.left);
                int rightHeight = CalculateHeight(root.right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }

            private int getBalancedFactor(Node root)
            {
                if (root == null) return 0;
                var leftHeight = CalculateHeight(root.left);
                var rightHeight = CalculateHeight(root.right);
                return leftHeight - rightHeight;
            }

            private Node leftRotate(Node node)
            {
                Node newNode = node.right;
                node.right = newNode.left;
                newNode.left = node;

                node.height = Math.Max(CalculateHeight(node.left), CalculateHeight(node.right)) + 1;
                newNode.height = Math.Max(CalculateHeight(newNode.left), CalculateHeight(newNode.right)) + 1;

                return newNode;

            }

            private Node rightRotate(Node node)
            {
                Node newNode = node.left;
                newNode.left = node.right;
                newNode.right = node;

                node.height = Math.Max(CalculateHeight(node.left), CalculateHeight(node.right)) + 1;
                newNode.height = Math.Max(CalculateHeight(newNode.left), CalculateHeight(newNode.right)) + 1;

                return newNode;

            }

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
        }
    }
}
