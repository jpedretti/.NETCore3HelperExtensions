using RJPSoft.HelperExtensions;
using Xunit;

namespace ExtensionsTests
{
    public class ClassExtensionsTest
    {
        [Fact]
        public void Let_WithNullReference_ShouldReturnNull()
        {
            TestClass? myNullreference = null;

            var result = myNullreference?.Let(n => $"my name is {n.Name}");

            Assert.Null(result);
        }

        [Fact]
        public void Let_WithValidInstance_ShouldReturnLetResult()
        {
            TestClass? myInstance = null;
            myInstance = new TestClass("Luke");

            var result = myInstance?.Let(n => $"my name is {n.Name}");

            Assert.Equal("my name is Luke", result);
        }

        [Fact]
        public void Run_WithNullReference_ShouldNotExecute()
        {
            TestClass? myNullReference = null;
            var name = "";
            myNullReference?.Run(n => name = n.Name);

            Assert.Equal("", name);
        }

        [Fact]
        public void Run_WithValidInstance_ShouldExecute()
        {
            TestClass? myinstance = null;
            myinstance = new TestClass("Luke");
            var name = string.Empty;

            myinstance?.Run(n => name = n.Name);

            Assert.Equal("Luke", name);
        }
    }
}
