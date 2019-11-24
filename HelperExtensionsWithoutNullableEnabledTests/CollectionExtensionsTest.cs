using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RJPSoft.HelperExtensions
{
    public class CollectionExtensionsTest
    {
        [Fact(DisplayName = "IEnumerable: Flatten should remove null from collection of class")]
        public void CollectionExtensions_IEnumerable_Flatten_Should_RemoveNull_Class()
        {
            var collection = new List<Uri>() { new Uri("file://local"), null, new Uri("https://github.com") }.AsEnumerable();
            var flattened = collection.FilterNotNull();
            flattened.Should().BeEquivalentTo(new Uri[] { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "IEnumerable: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_IEnumerable_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new List<int?> { 1, 2, null, 4, 5 }.AsEnumerable();
            var flattened = collection.FilterNotNull();
            flattened.Should().BeEquivalentTo(new int[] { 1, 2, 4, 5 });
        }

        [Fact(DisplayName ="IEnumerable of class: ForEachNotNull should execute action only for not null values")]
        public void CollectionExtensions_IEnumerableOfClass_ForEachNotNull_SHouldExecuteActionOnlyForNoNullValues()
        {
            var collection = new List<Uri>() { new Uri("file://local"), null, new Uri("https://github.com") }.AsEnumerable();
            var times = 0;
            var stringResult = new List<string>();

            collection.ForEachNotNull(value =>
            {
                times++;
                stringResult.Add(value.OriginalString);
            });

            times.Should().Be(2);
            stringResult.Count.Should().Be(2);
            stringResult[0].Should().Be("file://local");
            stringResult[1].Should().Be("https://github.com");
        }

        [Fact(DisplayName = "IEnumerable of struct: ForEachNotNull should execute action only for not null values")]
        public void CollectionExtensions_IEnumerableOfStruct_ForEachNotNull_SHouldExecuteActionOnlyForNoNullValues()
        {
            var collection = new List<int?> { 1, 2, null }.AsEnumerable();
            var times = 0;
            var intResult = new List<int>();

            collection.ForEachNotNull(value =>
            {
                times++;
                intResult.Add(value);
            });

            times.Should().Be(2);
            intResult.Count.Should().Be(2);
            intResult[0].Should().Be(1);
            intResult[1].Should().Be(2);
        }

        [Fact(DisplayName = "List: Flatten should remove null from collection of class")]
        public void CollectionExtensions_List_Flatten_Should_RemoveNull_Class()
        {
            var collection = new List<Uri>() { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<List<Uri>>();
            flattened.Should().Equal(new List<Uri>() { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "List: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_List_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new List<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<List<int>>();
            flattened.Should().Equal(new List<int>() { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "Array: Flatten should remove null from collection of class")]
        public void CollectionExtensions_Array_Flatten_Should_RemoveNull_Class()
        {
            var collection = new Uri[] { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<Uri[]>();
            flattened.Should().Equal(new Uri[] { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "Array: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_Array_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new int?[] { 1, 2, null, 4, 5 };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<int[]>();
            flattened.Should().Equal(new int[] { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "HashSet: Flatten should remove null from collection of class")]
        public void CollectionExtensions_HashSet_Flatten_Should_RemoveNull_Class()
        {
            var collection = new HashSet<Uri>() { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<HashSet<Uri>>();
            flattened.Should().Equal(new HashSet<Uri>() { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "HashSet: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_HashSet_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new HashSet<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<HashSet<int>>();
            flattened.Should().Equal(new HashSet<int>() { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of class")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Class()
        {
            var collection = new Dictionary<int, Uri>() { { 1, new Uri("file://local") }, { 2, null }, { 3, new Uri("https://github.com") } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<Dictionary<int, Uri>>();
            flattened.Should().BeEquivalentTo(new Dictionary<int, Uri?>() { { 1, new Uri("file://local") }, { 3, new Uri("https://github.com") } });
        }

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new Dictionary<string, int?>() { { "1", 1 }, { "2", null }, { "3", 3 } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<Dictionary<string, int>>();
            flattened.Should().BeEquivalentTo(new Dictionary<string, int>() { { "1", 1 }, { "3", 3 } });
        }
    }
}
