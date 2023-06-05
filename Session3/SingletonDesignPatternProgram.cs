using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            private static SingletonLazy instance = new SingletonLazy();
            private SingletonLazy()
            {

            }

            public static SingletonLazy GetInstance()
            {
                return instance;
            }

        }
    }
}
