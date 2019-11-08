using Jp.HelperExtensions;
using Xunit;

namespace ExtensionsTests
{
    public class ClassToStructExtensionsTest
    {
        [Fact]
        public void Let_WithNullReference_ShouldReturnNull()
        {
            TestClass? myNullreference = null;

            var result = myNullreference?.Let(n => n.Age);

            Assert.Null(result);
        }

        [Fact]
        public void Let_WithValidInstance_ShouldReturnLetResult()
        {
            TestClass? myInstance = null;
            myInstance = new TestClass(17);

            var result = myInstance?.Let(n => n.Age);

            Assert.Equal(17, result);
        }
    }
}
