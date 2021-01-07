using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class PhoneNumberAttribute : RegexAttribute
    {
        public override string Pattern { get; }
        public override string Error { get; set; }
        public PhoneNumberAttribute(string pattern)
        {
            Pattern = pattern;
        }
    }
}