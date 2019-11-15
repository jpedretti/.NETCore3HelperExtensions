using RJPSoft.HelperExtensions;
using Xunit;

namespace ExtensionsTests
{
    public class StructToClassExtensionsTest
    {
        [Fact]
        public void Let_WithNullReference_ShouldReturnNull()
        {
            int? myNullStruct = null;

            var result = myNullStruct.Let(n => new TestClass(n.ToString()));

            Assert.Null(result);
        }

        [Fact]
        public void Let_WithValidInstance_ShouldReturnLetResult()
        {
            int? myStruct = 17;

            var result = myStruct.Let(n => new TestClass(n.ToString()));

            Assert.Equal("17", result!.Name);
        }
    }
}
