using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionsTests
{
    public class TestClass
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public TestClass(string name)
        {
            Name = name;
        }

        public TestClass(int age)
        {
            Age = age;
            Name = "no name";
        }
    }
}
