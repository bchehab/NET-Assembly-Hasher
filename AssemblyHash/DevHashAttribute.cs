using System;
using System.Reflection;

namespace AssemblyHash
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class DevHashAttribute: Attribute
    {
        string hashText;
        public DevHashAttribute() : this(string.Empty) { }
        public DevHashAttribute(string txt) { hashText = txt; }
    }
}
