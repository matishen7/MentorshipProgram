using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var my_heap = new MyHeap(new int[] { 75, 50, 25, 45, 35, 10, 15, 20, 40 });
            Console.WriteLine(my_heap.isEmpty());

            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine(my_heap.Pop());
            Console.WriteLine("Size = " + my_heap.Size());
            Console.WriteLine(my_heap.isEmpty());
            my_heap.Insert(5);
            Console.WriteLine("Max value = " + my_heap.Peek());
        }

        public class MyHeap
        {
            private int[] elements = new int[] { };
            private int index = 0;
            public MyHeap()
            {
                elements = new int[] { };
            }

            public MyHeap(int[] el)
            {
                this.elements = el;
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
                        ResizeWhenInsert();
                    elements[index] = value;
                    HeapifyWhenInsert(index);
                    index++;
                }

            }


            public int Peek()
            {
                return (elements.Length > 0) ? elements[0] : throw new Exception("No elements found!");
            }

            public int Pop()
            {
                int result;
                if (elements.Length <= 0)
                    throw new Exception("No elements found!");
                else
                {
                    result = elements[0];
                    swap(elements, 0, elements.Length - 1);

                    ResizeWhenPop();
                    HeapifyWhenPop(0);
                    index = elements.Length;

                }
                return result;
            }

            public int Size()
            {
                return elements.Length;
            }

            public bool isEmpty()
            {
                return elements.Length == 0;
            }

            private void HeapifyWhenInsert(int idx)// Big O O(logN)
            {

                var parentIndex = (int)Math.Floor((idx - 1) / 2.0);
                while (elements[parentIndex] < elements[idx])
                {
                    swap(elements, parentIndex, idx);
                    idx = parentIndex;
                    parentIndex = (int)Math.Floor((idx - 1) / 2.0);
                    if (parentIndex < 0) break;
                }
            }

            private void HeapifyWhenPop(int idx) // Big O O(logN)
            {
                int indexToSwap;
                var leftIndex = (idx * 2) + 1;
                if (leftIndex >= elements.Length) return;
                var rightIndex = (idx * 2) + 2;
                if (rightIndex >= elements.Length)
                    indexToSwap = (elements[idx] < elements[leftIndex]) ? leftIndex : idx;
                
                else
                    indexToSwap = (elements[rightIndex] < elements[leftIndex]) ? leftIndex : rightIndex;

                if (elements[idx] < elements[indexToSwap])
                {
                    swap(elements, idx, indexToSwap);
                    idx = indexToSwap;
                    HeapifyWhenPop(idx);
                }
            }

            private void swap(int[] elements, int targetIdx, int sourceIdx)
            {
                int temp = elements[sourceIdx];
                elements[sourceIdx] = elements[targetIdx];
                elements[targetIdx] = temp;
            }

            private void ResizeWhenInsert()
            {
                var newElements = new int[elements.Length + 1];
                elements.CopyTo(newElements, 0);
                elements = newElements;
            }

            private void ResizeWhenPop()
            {
                var newElements = new int[elements.Length - 1];
                int t = 0;
                for (int i = 0; i < elements.Length - 1; i++)
                    newElements[t++] = elements[i];
                elements = newElements;
            }
        }
    }
}
