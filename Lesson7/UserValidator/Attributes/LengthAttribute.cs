using System;

namespace ObjectValidator
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class LengthAttribute : MyBaseAttribute
    {
        public int MinLength { get; }
        public int MaxLength { get; }
        public override string Error { get; set; }
        public LengthAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
    }
}