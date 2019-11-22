using System.Collections.Generic;
using System.Linq;

namespace RJPSoft.HelperExtensions
{
    public static class CollectionExtensions
    {
        #region IEnumerable

        public static IEnumerable<T> NonNullEnumerable<T>(this IEnumerable<T?> collection) where T : class =>
            NonNull(collection);

        public static IEnumerable<T> NonNullEnumerable<T>(this IEnumerable<T?> collection) where T : struct =>
            NonNull(collection);

        public static IEnumerable<T> NonNull<T>(this IEnumerable<T?> collection) where T : class =>
            collection.Where(t => t != null).Select(t => t!);

        public static IEnumerable<T> NonNull<T>(this IEnumerable<T?> collection) where T : struct =>
            collection.Where(i => i.HasValue).Select(i => i!.Value);

        #endregion IEnumerable

        #region List

        public static List<T> NonNull<T>(this List<T?> collection) where T : class
        {
            var nonNull = new List<T>();
            foreach (var item in collection)
            {
                if (item is T valueOfT) nonNull.Add(valueOfT);
            }
            return nonNull;
        }

        public static List<T> NonNull<T>(this List<T?> collection) where T : struct
        {
            var nonNull = new List<T>();
            foreach (var item in collection)
            {
                if (item is T valueOfT) nonNull.Add(valueOfT);
            }
            return nonNull;
        }

        #endregion List

        #region Array

        public static T[] NonNull<T>(this T?[] collection) where T : class
        {
            var nonNullCount = collection.Count(t => t != null);
            var nonNull = new T[nonNullCount];
            int n = 0;
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] is T valueOfT)
                {
                    nonNull[n] = valueOfT;
                    n++;
                }
            }
            return nonNull;
        }


        public static T[] NonNull<T>(this T?[] collection) where T : struct
        {
            var nonNullCount = collection.Count(t => t != null);
            var nonNull = new T[nonNullCount];
            int n = 0;
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] is T valueOfT)
                {
                    nonNull[n] = valueOfT;
                    n++;
                }
            }
            return nonNull;
        }

        #endregion Array

        #region Set

        public static HashSet<T> NonNull<T>(this HashSet<T?> collection) where T : class
        {
            var nonNull = new HashSet<T>();
            foreach (var item in collection)
            {
                if (item is T valueOfT) nonNull.Add(valueOfT);
            }
            return nonNull;
        }

        public static HashSet<T> NonNull<T>(this HashSet<T?> collection) where T : struct
        {
            var nonNull = new HashSet<T>();
            foreach (var item in collection)
            {
                if (item is T valueOfT) nonNull.Add(valueOfT);
            }
            return nonNull;
        }
        #endregion Set

        #region Dictionary

        public static Dictionary<T, U> NonNull<T, U>(this Dictionary<T, U?> collection) where T : notnull where U : class
        {
            var nonNull = new Dictionary<T, U>();
            foreach (var item in collection)
            {
                if (item.Value is U valueOfU) nonNull.Add(item.Key, valueOfU);
            }
            return nonNull;
        }

        public static Dictionary<T, U> NonNull<T, U>(this Dictionary<T, U?> collection) where T : notnull where U : struct
        {
            var nonNull = new Dictionary<T, U>();
            foreach (var item in collection)
            {
                if (item.Value is U valueOfU) nonNull.Add(item.Key, valueOfU);
            }
            return nonNull;
        }

        #endregion Dictionary

    }
}