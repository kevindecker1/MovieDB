using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public class EnumNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public EnumNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
