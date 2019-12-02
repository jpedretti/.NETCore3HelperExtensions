using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace RJPSoft.HelperExtensions
{
    public class CollectionExtensionsTest
    {
        #region IEnumerable

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

        [Fact(DisplayName = "IEnumerable of class: ForEachNotNull should execute action only for not null values")]
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

        #endregion

        #region List

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

        [Fact(DisplayName = "LinkedList: Flatten should remove null from collection of class")]
        public void CollectionExtensions_LinkedList_Flatten_Should_RemoveNull_Class()
        {
            var collection = new LinkedList<Uri>(new Uri[] { new Uri("file://local"), null, new Uri("https://github.com") });
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<LinkedList<Uri>>();
            flattened.Should().BeEquivalentTo(
                new LinkedList<Uri>(new Uri[] { new Uri("file://local"), new Uri("https://github.com") }),
                options => options.WithStrictOrdering()
            );
        }

        [Fact(DisplayName = "LinkedList: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_LinkedList_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new LinkedList<int?>(new int?[] { 1, 2, null, 4, 5 });
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<LinkedList<int>>();
            flattened.Should().BeEquivalentTo(
                new LinkedList<int>(new int[] { 1, 2, 4, 5 }),
                options => options.WithStrictOrdering()
            );
        }

        [Fact(DisplayName = "SortedList: Flatten should remove null from collection of class")]
        public void CollectionExtensions_SortedList_Flatten_Should_RemoveNull_Class()
        {
            var collection = new SortedList<string, Uri>() { { "3", new Uri("file://local") }, { "1", null }, { "2", new Uri("https://github.com") } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<SortedList<string, Uri>>();
            flattened.Should().BeEquivalentTo(
                new SortedList<string, Uri>() { { "3", new Uri("file://local") }, { "2", new Uri("https://github.com") } },
                options => options.WithStrictOrdering()
            );
        }

        [Fact(DisplayName = "SortedList: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_SortedList_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new SortedList<string, int?>() { { "3", 3 }, { "1", null }, { "2", 2 } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<SortedList<string, int>>();
            flattened.Should().BeEquivalentTo(
                new SortedList<string, int?>() { { "3", 3 }, { "2", 2 } },
                options => options.WithStrictOrdering()
            );
        }

        #endregion

        #region Array

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

        #endregion

        #region Set

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

        [Fact(DisplayName = "HashSet with comparer: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_HashSet_Comparer_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new HashSet<MyStruct?>(new MyStructEqualityCompararNullable()) {
                new MyStruct { Id = 1 },
                new MyStruct { Id = 2 },
                new MyStruct { Id = 1 },
                null,
                new MyStruct { Id = 4 },
                new MyStruct { Id = 5 } };
            var flattened = collection.FilterNotNull(new MyStructEqualityComparar());
            flattened.Should().BeOfType<HashSet<MyStruct>>();
            flattened.Should().Equal(new HashSet<MyStruct>() { new MyStruct { Id = 1 }, new MyStruct { Id = 2 }, new MyStruct { Id = 4 }, new MyStruct { Id = 5 } });
        }

        [Fact(DisplayName = "SortedSet: Flatten should remove null from collection of class")]
        public void CollectionExtensions_SortedSet_Flatten_Should_RemoveNull_Class()
        {
            var comparer = new UriComparer();
            var collection = new SortedSet<Uri>(comparer) { new Uri("file://local"), null, new Uri("https://github.com") };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<SortedSet<Uri>>();
            flattened.Should().Equal(new SortedSet<Uri>(comparer) { new Uri("file://local"), new Uri("https://github.com") });
        }

        [Fact(DisplayName = "SortedSet: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_SortedSet_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new SortedSet<int?> { 1, 2, null, 4, 5 };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<SortedSet<int>>();
            flattened.Should().Equal(new SortedSet<int>() { 1, 2, 4, 5 });
        }

        [Fact(DisplayName = "SortedSet wit comparer: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_SortedSet_Comparer_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new SortedSet<MyStruct?>(new MyStructCompararNullable()) {
                new MyStruct { Id = 1 }, new MyStruct { Id = 2 },
                new MyStruct { Id = 1 },
                null,
                new MyStruct { Id = 4 }, new MyStruct { Id = 5 }
            };

            var flattened = collection.FilterNotNull(new MyStructComparar());
            flattened.Should().BeOfType<SortedSet<MyStruct>>();
            flattened.Should().Equal(new SortedSet<MyStruct>(new MyStructComparar()) {
                new MyStruct { Id = 1 },
                new MyStruct { Id = 2 },
                new MyStruct { Id = 4 },
                new MyStruct { Id = 5 }
            });
        }

        #endregion

        #region Dictionary

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of class")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Class()
        {
            var collection = new Dictionary<int, Uri>() { { 1, new Uri("file://local") }, { 2, null }, { 3, new Uri("https://github.com") } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<Dictionary<int, Uri>>();
            flattened.Should().BeEquivalentTo(new Dictionary<int, Uri>() { { 1, new Uri("file://local") }, { 3, new Uri("https://github.com") } });
        }

        [Fact(DisplayName = "Dictionary: Flatten should remove null from collection of struct")]
        public void CollectionExtensions_Dictionary_Flatten_Should_RemoveNull_Struct()
        {
            var collection = new Dictionary<string, int?>() { { "1", 1 }, { "2", null }, { "3", 3 } };
            var flattened = collection.FilterNotNull();
            flattened.Should().BeOfType<Dictionary<string, int>>();
            flattened.Should().BeEquivalentTo(new Dictionary<string, int>() { { "1", 1 }, { "3", 3 } });
        }

        #endregion

        class UriComparer : IComparer<Uri>
        {
            public int Compare([AllowNull] Uri x, [AllowNull] Uri y)
            {
                if (x != null && y != null)
                {
                    return x.ToString().CompareTo(y.ToString());
                }

                return x != null ? 1 : -1;
            }
        }

        struct MyStruct
        {
            public int Id { get; set; }
        }

        struct MyStructCompararNullable : IComparer<MyStruct?>
        {
            public int Compare([AllowNull] MyStruct? x, [AllowNull] MyStruct? y)
            {
                if (x is MyStruct vX && y is MyStruct vY)
                {
                    return vX.Id.CompareTo(vY.Id);
                }

                return x != null ? 1 : -1;
            }
        }

        struct MyStructComparar : IComparer<MyStruct>
        {
            public int Compare([AllowNull] MyStruct x, [AllowNull] MyStruct y) => x.Id.CompareTo(y.Id);
        }

        struct MyStructEqualityCompararNullable : IEqualityComparer<MyStruct?>
        {
            public bool Equals([AllowNull] MyStruct? x, [AllowNull] MyStruct? y) => x?.Id == y?.Id;

            public int GetHashCode([DisallowNull] MyStruct? obj) => obj.Value.Id;
        }

        struct MyStructEqualityComparar : IEqualityComparer<MyStruct>
        {
            public bool Equals([AllowNull] MyStruct x, [AllowNull] MyStruct y) => x.Id == y.Id;

            public int GetHashCode([DisallowNull] MyStruct obj) => obj.Id;
        }
    }
}
