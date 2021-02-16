using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    abstract public class MyBaseAttribute : Attribute
    {
        abstract public string Error { get; set; }
    }
}