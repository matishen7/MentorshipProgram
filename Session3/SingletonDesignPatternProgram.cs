using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MentorshipProgram.Session3
{
    [TestClass]
    public class SingletonDesignPatternProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            var eager_singleton = SingletonEager.GetInstance();
            Console.WriteLine(eager_singleton.GetHashCode()); // hashcode is equal, because it is the same instance 

            var eager_singleton2 = SingletonEager.GetInstance();
            Console.WriteLine(eager_singleton2.GetHashCode());

            var lazy_singleton = SingletonLazy.GetInstance();
            Console.WriteLine(lazy_singleton.GetHashCode());// hashcode is equal, because it is the same instance

            var lazy_singleton2 = SingletonLazy.GetInstance();
            Console.WriteLine(lazy_singleton2.GetHashCode());

            new Thread(() => {
                var lazy_singletonThreadSafe = SingletonThreadSafe.GetInstance();
                Console.WriteLine(lazy_singletonThreadSafe.GetHashCode());

            });

            new Thread(() => {
                var lazy_singletonThreadSafe2 = SingletonThreadSafe.GetInstance();
                Console.WriteLine(lazy_singletonThreadSafe2.GetHashCode());

            });
        }

        public class SingletonEager
        {
            private static SingletonEager instance = new SingletonEager();
            private SingletonEager()
            {

            }

            public static SingletonEager GetInstance()
            {
                return instance;
            }

        }

        public class SingletonLazy
        {
            private static SingletonLazy instance = null;
            private SingletonLazy()
            {

            }

            public static SingletonLazy GetInstance()
            {
                if (instance == null)
                    instance = new SingletonLazy();
                return instance;
            }

        }

        public class SingletonThreadSafe
        {
            private static SingletonThreadSafe instance = null;
            private static object _lock = new object();
            private SingletonThreadSafe()
            {

            }

            public static SingletonThreadSafe GetInstance()
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                            instance = new SingletonThreadSafe();
                    }
                }
                return instance;
            }

        }
    }
}
