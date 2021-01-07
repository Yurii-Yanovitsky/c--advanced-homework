using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RequiredAttribute : MyBaseAttribute
    {
        public override string Error { get; set; }
    }
}