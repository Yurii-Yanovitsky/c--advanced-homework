using System;
using System.Reflection;

namespace Task3
{
    public class Reflector
    {
        Assembly _assembly;
        string[] _memberTypes;

        public Reflector(Assembly assembly, string[] memberTypes)
        {
            _assembly = assembly;
            _memberTypes = memberTypes;
        }

        public void GetTypeAndMembersInfo()
        {
            var types = _assembly.GetTypes();

            if (types != null)
            {
                foreach (var type in types)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(new string('-', 100));

                    Console.WriteLine($"ТИП: {type.FullName}");

                    var (isAttr, attrInfo) = GetAttributes(type);
                    
                    if (isAttr)
                    {
                        Console.WriteLine($"АТРИБУТЫ ТИПА: {attrInfo}");
                    }

                    Console.WriteLine(new string('-', 100));
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    GetMembersInfo(type);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
        }
        private void GetMembersInfo(Type type)
        {
            foreach (var m in _memberTypes)
            {
                switch (m)
                {
                    case "method":
                        ListOfMembers(() => type.GetMethods(), m);
                        break;
                    case "prop":
                        ListOfMembers(() => type.GetProperties(), m);
                        break;
                    case "field":
                        ListOfMembers(() => type.GetFields(), m);
                        break;
                    case "ctor":
                        ListOfMembers(() => type.GetConstructors(), m);
                        break;
                    case "interface":
                        ListOfMembers(() => type.GetInterfaces(), m);
                        break;
                };
            }
        }

        private void ListOfMembers(Func<MemberInfo[]> func, string memberType)
        {
            MemberInfo[] members = func.Invoke();

            foreach (var member in members)
            {
                Console.WriteLine(new string(' ', 3) + $"{memberType.ToUpper()}: {member.Name}");

                var (isAttr, attrInfo) = GetAttributes(member);

                if (isAttr)
                {
                    Console.WriteLine(new string(' ', 3) + $"АТРИБУТЫ ЧЛЕНА: {attrInfo}");
                }

                Console.WriteLine(new string('-', 100));
            }
        }

        private (bool, string) GetAttributes(ICustomAttributeProvider member)
        {
            string attrInfo = "";
            var attributes = member.GetCustomAttributes(false);
            if (attributes.Length > 0)
            {
                foreach (var attr in attributes)
                {
                    attrInfo += attr + " ";
                }
                return (true, attrInfo);
            }
            return (false, null);
        }
    }
}
