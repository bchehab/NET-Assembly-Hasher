using System;

namespace AssemblyHash
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class ReleaseHashAttribute: Attribute
    {
        string hashText;
        public ReleaseHashAttribute() : this(string.Empty) { }
        public ReleaseHashAttribute(string txt) { hashText = txt; }
    }
}
