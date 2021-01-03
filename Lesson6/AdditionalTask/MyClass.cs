using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalTask
{
    public class MyClass<T> : IInterface1, IInterface2
    {
        // Поля.         
        public T myint;
        private string mystring = "Hello";

        // Конструкторы.
        public MyClass() { }
        public MyClass(T i)
        {
            this.myint = i;
        }

        // Свойства.
        public T myProp
        {
            get { return myint; }
            set { myint = value; }
        }

        public string MyString
        {
            get { return mystring; }
        }

        // Методы.
        public void MethodA() { }
        public void MethodB() { }

        private void MethodC(string str, string str2)
        {
            Console.WriteLine(str + str2);
        }

        public void myMethod(int p1, string p2) { }
    }
}
