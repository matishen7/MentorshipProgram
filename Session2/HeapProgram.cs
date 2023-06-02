﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MentorshipProgram.Session2
{
    [TestClass]
    public class HeapProgram
    {
        /// <summary>
        /// parent = floor((index-1)/2)
        /// left = index*2+1
        /// right = index*2+2
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var my_heap = new MyHeap();
            Console.WriteLine(my_heap.isEmpty());

            for (int i = 0; i < 10; i++)
            {
                my_heap.Insert(i);
            }
            Console.WriteLine(my_heap.Size());
            Console.WriteLine(my_heap.isEmpty());
        }

        public class MyHeap
        {
            private int[] elements = new int[] { };
            private int index = 0;
            public MyHeap()
            {
                elements = new int[] { };
            }

            public MyHeap(int[] elements)
            {
                this.elements = elements;
                index = elements.Length;
            }

            public MyHeap(int size)
            {
                elements = new int[size];
            }

            public void Insert(int value)
            {
                if (elements.Length == 0)
                {
                    elements = new int[1];
                    elements[index++] = value;
                }
                else
                {
                    if (index >= elements.Length)
                        Resize();
                    elements[index] = value;
                    Heapify(index);
                    index++;
                }

            }

            public int Peek()
            {
                return (elements.Length > 0 )? elements[0] : throw new Exception("No elements found!");
            }

            //public int Pop()
            //{
                
            //}

            public int Size()
            {
                return index;
            }

            public bool isEmpty()
            {
                return elements.Length == 0;
            }

            private void Heapify(int idx)
            {

                var parentIndex =(int)Math.Floor((idx - 1) / 2.0);
                while(elements[parentIndex] < elements[idx])
                {
                    swap(elements, parentIndex, idx);
                    idx = parentIndex;
                    parentIndex = (int)Math.Floor((idx - 1) / 2.0);
                    if (parentIndex < 0) break;
                }
            }

            private void swap(int[] elements, int targetIdx, int sourceIdx)
            {
                int temp = elements[sourceIdx];
                elements[sourceIdx] = elements[targetIdx];
                elements[targetIdx] = temp;
            }

            private void Resize()
            {
                var newElements = new int[elements.Length + 1];
                elements.CopyTo(newElements, 0);
                elements = newElements;
            }
        }
    }
}
