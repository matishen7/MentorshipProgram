using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static MentorshipProgram.Session2.MyQueueProgram;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MentorshipProgram.Session4
{
    [TestClass]
    public class Performance
    {
        static void Profile(string description, int iterations, Action func)
        {

            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            // warm up 
            func();
            // clean up
            GC.Collect();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var queue = new MyQueue();
            var q = new Queue<int>();
            int iterations = Int32.MaxValue / 2;
            int i = int.MinValue;
            Profile("my queue", iterations, () =>
            {
                queue.Push(i);
                queue.Pop();
            });

            i = int.MinValue;
            Profile("original queue push", iterations, () =>
            {
                q.Enqueue(i);
                q.Dequeue();
            });
        }
    }
}
