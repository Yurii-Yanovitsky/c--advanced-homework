using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EmailAttribute : RegexAttribute
    {
        public override string Pattern { get; }
        public override string Error { get; set; }
        public EmailAttribute(string pattern, string error)
        {
            Pattern = pattern;
        }
    }
}