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
            var collection = new List<Uri?>() { new Uri("file://local"), null, new Uri("https://github.com") }.AsEnumerable();
            var flattened = collection.NonNull();
            flattened.Should().BeEquivalentTo(new Uri[] { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "IEnumerable: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_IEnumerable_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new List<int?> { 1, 2, null, 4, 5 }.AsEnumerable();
            var flattened = collection.NonNull();
            flattened.Should().BeEquivalentTo(new int[] { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "To IEnumerable: Flatten should remove null from collection of class")]
        public void CollectionExtensions_To_IEnumerable_Flatten_Should_RemoveNull_Class()
        {
            var collection = new List<Uri?>() { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.NonNullEnumerable();
            flattened.Should().NotBeOfType<List<Uri>>();
            flattened.Should().BeEquivalentTo(new Uri[] { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "To IEnumerable: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_To_IEnumerable_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new List<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.NonNullEnumerable();
            flattened.Should().NotBeOfType<List<int>>();
            flattened.Should().BeEquivalentTo(new int[] { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "List: Flatten should remove null from collection of class")]
        public void CollectionExtensions_List_Flatten_Should_RemoveNull_Class()
        {
            var collection = new List<Uri?>() { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<List<Uri>>();
            flattened.Should().Equal(new List<Uri>() { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "List: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_List_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new List<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<List<int>>();
            flattened.Should().Equal(new List<int>() { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "Array: Flatten should remove null from collection of class")]
        public void CollectionExtensions_Array_Flatten_Should_RemoveNull_Class()
        {
            var collection = new Uri?[] { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<Uri[]>();
            flattened.Should().Equal(new Uri[] { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "Array: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_Array_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new int?[] { 1, 2, null, 4, 5 };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<int[]>();
            flattened.Should().Equal(new int[] { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "HashSet: Flatten should remove null from collection of class")]
        public void CollectionExtensions_HashSet_Flatten_Should_RemoveNull_Class()
        {
            var collection = new HashSet<Uri?>() { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<HashSet<Uri>>();
            flattened.Should().Equal(new HashSet<Uri>() { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "HashSet: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_HashSet_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new HashSet<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<HashSet<int>>();
            flattened.Should().Equal(new HashSet<int>() { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of class")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Class()
        {
            var collection = new Dictionary<int, Uri?>() { { 1, new Uri("file://local") }, { 2, null }, { 3, new Uri("https://github.com") } };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<Dictionary<int, Uri>>();
            flattened.Should().BeEquivalentTo(new Dictionary<int, Uri?>() { { 1, new Uri("file://local") }, { 3, new Uri("https://github.com") } });
        }

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new Dictionary<string, int?>() { { "1", 1 }, { "2", null }, { "3", 3 } };
            var flattened = collection.NonNull();
            flattened.Should().BeOfType<Dictionary<string, int>>();
            flattened.Should().BeEquivalentTo(new Dictionary<string, int>() { { "1", 1 }, { "3", 3 } });
        }
    }
}
