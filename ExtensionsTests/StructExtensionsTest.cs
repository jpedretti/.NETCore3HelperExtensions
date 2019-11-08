using Xunit;
using Jp.HelperExtensions;

namespace ExtensionsTests
{
    public class StructExtensionsTest
    {
        [Fact]
        public void Let_WithNullReference_ShouldReturnNull()
        {
            int? myNullStruct = null;

            var result = myNullStruct?.Let(n => n);

            Assert.Null(result);
        }

        [Fact]
        public void Let_WithValidInstance_ShouldReturnLetResult()
        {
            int? myStruct = 17;

            var result = myStruct?.Let(n => n);

            Assert.Equal(17, result);
        }

        [Fact]
        public void Run_WithNullReference_ShouldNotExecute()
        {
            int? myNullStruct = null;
            var age = 0;
            myNullStruct?.Run(n => age = n);

            Assert.Equal(0, age);
        }

        [Fact]
        public void Run_WithValidInstance_ShouldExecute()
        {
            int? mystruct = 17;
            var age = 0;

            mystruct?.Run(n => age = n);

            Assert.Equal(17, age);
        }
    }
}
