using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RJPSoft.HelperExtensions
{
    public struct MyStruct
    {
        public int Id { get; set; }
    }

    public struct MyStructComparerNullable : IComparer<MyStruct?>
    {
        public int Compare(MyStruct? x, MyStruct? y)
        {
            if (x is MyStruct vX && y is MyStruct vY)
            {
                return vX.Id.CompareTo(vY.Id);
            }

            return x != null ? 1 : -1;
        }
    }

    public struct MyStructComparer : IComparer<MyStruct>
    {
        public int Compare(MyStruct x, MyStruct y) => x.Id.CompareTo(y.Id);
    }

    public struct MyStructEqualityComparerNullable : IEqualityComparer<MyStruct?>
    {
        public bool Equals([AllowNull] MyStruct? x, [AllowNull] MyStruct? y) => x?.Id == y?.Id;

        public int GetHashCode([DisallowNull] MyStruct? obj) => obj.Value.Id.GetHashCode();
    }

    public struct MyStructEqualityComparer : IEqualityComparer<MyStruct>
    {
        public bool Equals([AllowNull] MyStruct x, [AllowNull] MyStruct y) => x.Id == y.Id;

        public int GetHashCode([DisallowNull] MyStruct obj) => obj.Id.GetHashCode();
    }
}
