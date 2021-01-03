using System;
using System.Reflection;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass<int>);

            SomeClassInfo(type);
            ListMethods(type);
            ListFields(type);
            ListProperties(type);
            ListConstructors(type);
            ListInterfaces(type);
            ListGenericArguments(type);

            Console.ReadLine();
        }
        static void SomeClassInfo(Type type)
        {
            Console.WriteLine(new string('-', 15));
            Console.WriteLine("MyClass info");
            Console.WriteLine(new string('-', 15));

            Console.WriteLine($"Name: {type.FullName}");
            Console.WriteLine($"Base type: {type.BaseType}");
            Console.WriteLine($"Is it a class?: {type.IsClass}");
            Console.WriteLine($"Is it an abstract class?: {type.IsAbstract}");
            Console.WriteLine($"Is it a sealed class?: {type.IsSealed}");
            Console.WriteLine($"Is it an interface {type.IsInterface}");
        }
        static void ListMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass methods:");
            Console.WriteLine(new string('-', 17));

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        static void ListProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass properties:");
            Console.WriteLine(new string('-', 17));

            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
            }
        }

        static void ListFields(Type type)
        {
            FieldInfo[] fields = type.GetFields();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass fields:");
            Console.WriteLine(new string('-', 17));

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
            }
        }

        static void ListConstructors(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass constructors:");
            Console.WriteLine(new string('-', 17));

            foreach (var ctor in constructors)
            {
                Console.WriteLine(ctor.Name);
            }
        }

        static void ListInterfaces(Type type)
        {
            Type[] interfaces = type.GetInterfaces();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass interfaces:");
            Console.WriteLine(new string('-', 17));

            foreach (var inter in interfaces)
            {
                Console.WriteLine(inter.Name);
            }
        }

        static void ListGenericArguments(Type type)
        {
            Type[] genericArgs = type.GetGenericArguments();

            Console.WriteLine(new string('-', 17));
            Console.WriteLine("MyClass generic arguments:");
            Console.WriteLine(new string('-', 17));

            foreach (var arg in genericArgs)
            {
                Console.WriteLine(arg.Name);
            }
        }
    }
}

