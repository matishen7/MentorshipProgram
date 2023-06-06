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

