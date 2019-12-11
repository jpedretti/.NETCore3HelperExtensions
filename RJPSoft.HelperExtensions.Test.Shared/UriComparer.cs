using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RJPSoft.HelperExtensions
{
    public class NullableUriComparer : IComparer<Uri?>
    {
        public int Compare(Uri? x, Uri? y)
        {
            if (x is Uri xV && y is Uri yV)
            {
                return xV.ToString().CompareTo(yV.ToString());
            }

            return x != null ? 1 : -1;
        }
    }

    public class NullableUriEqualityComparer : IEqualityComparer<Uri?>
    {
        public bool Equals([AllowNull] Uri? x, [AllowNull] Uri? y)
        {
            if (x is Uri xV && y is Uri yV)
            {
                return xV.Equals(yV);
            }

            return false;
        }

        public int GetHashCode([DisallowNull] Uri? obj)
        {
            return obj!.GetHashCode();
        }
    }
}
