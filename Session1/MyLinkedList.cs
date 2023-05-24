using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class MyLinkedList
    {
        [TestMethod]
        public void LinkedListProgram()
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Traverse();
            list.Remove(1);
            list.Traverse();
            list.Add(3);
            list.Add(4);
            list.Traverse();
            list.Remove(4);
            list.Traverse();
        }

        public class LinkedList
        {
            private Node head;

            public void Add(int value)
            {
                Node newNode = new Node(value);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node currentNode = head;
                    while (currentNode.next != null)
                    {
                        currentNode = currentNode.next;
                    }
                    currentNode.next = newNode;
                }
            }

            public void Traverse()
            {
                Console.WriteLine("----------------");
                Node current = head;
                if (current == null) return;
                else
                {
                    Console.WriteLine(current.value);
                    while (current.next != null)
                    {
                        current = current.next;
                        Console.WriteLine(current.value);
                    }
                }
            }

            public void Remove(int value)
            {
                Node curr = head;
                Node prev = null;
                while (curr != null)
                {
                    if (curr.value == value)
                    {
                        if (curr == head)
                        {
                            head = head.next;
                        }
                        else
                        {
                            prev.next = curr.next;
                            curr = head;
                        }

                    }
                    prev = curr;
                    curr = curr.next;
                }
            }
        }

        public class Node
        {
            public int value;
            public Node next;
            public Node(int val) { this.value = val; }
            public Node()
            {

            }
        }
    }
}
