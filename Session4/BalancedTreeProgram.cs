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
                this.height = 0; // Initialize height to 0
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

        private Node InsertNode(Node node, int value)
        {
            if (node == null)
            {
                node = new Node(value);
                return node;
            }

            if (value < node.value)
                node.left = InsertNode(node.left, value);
            else if (value > node.value)
                node.right = InsertNode(node.right, value);
            else
            {
                // Value already exists in the tree, handle accordingly
                return node;
            }

            // Update height of the current node
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));

            // Perform rotations if necessary to balance the tree
            int balanceFactor = GetBalanceFactor(node);

            // Left Left Case
            if (balanceFactor > 1 && value < node.left.value)
                return RightRotate(node);

            // Right Right Case
            if (balanceFactor < -1 && value > node.right.value)
                return LeftRotate(node);

            // Left Right Case
            if (balanceFactor > 1 && value > node.left.value)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balanceFactor < -1 && value < node.right.value)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return node.height;
        }

        private int GetBalanceFactor(Node node)
        {
            if (node == null)
                return 0;

            return GetHeight(node.left) - GetHeight(node.right);
        }

        private Node LeftRotate(Node node)
        {
            Node newRoot = node.right;
            Node leftSubtree = newRoot.left;

            // Perform rotation
            newRoot.left = node;
            node.right = leftSubtree;

            // Update heights
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            newRoot.height = 1 + Math.Max(GetHeight(newRoot.left), GetHeight(newRoot.right));

            return newRoot;
        }

        private Node RightRotate(Node node)
        {
            Node newRoot = node.left;
            Node rightSubtree = newRoot.right;

            // Perform rotation
            newRoot.right = node;
            node.left = rightSubtree;

            // Update heights
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            newRoot.height = 1 + Math.Max(GetHeight(newRoot.left), GetHeight(newRoot.right));

            return newRoot;
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
