using System;

namespace ProtoGTFS.Common
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class TagAttribute : Attribute
    {
        public TagAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class Key : Attribute
    {
        public Key() { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class Required : Attribute
    {
        public Required() { }
    }
}
