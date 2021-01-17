using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public class ParameterNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public ParameterNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
