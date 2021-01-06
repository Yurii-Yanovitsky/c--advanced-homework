using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            myClass.Method1();
            //myClass.Method2();
        }
    }
    class MyClass
    {
        [Obsolete("This is an old method. Use new instead! ")]
        public void Method1()
        {

        }

        [Obsolete("This is an old method. Use new instead!", true)]
        public void Method2()
        {

        }
    }
}
