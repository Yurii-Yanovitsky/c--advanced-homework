using System;

namespace AdditionalTask
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class AccessLevelAttribute : Attribute
    {
        public AccessLevel AccessLevel { get; }

        public AccessLevelAttribute(AccessLevel accessLevel)
        {
            AccessLevel = accessLevel;
        }
    }
}
