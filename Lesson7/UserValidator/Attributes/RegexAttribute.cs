using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    abstract public class RegexAttribute : MyBaseAttribute
    {
        abstract public string Pattern { get; }
    }
}