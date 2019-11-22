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

        public static List<T> NonNull<T>(this List<T?> collection) where T : class =>
            collection.Where(t => t != null).Select(t => t!).ToList();

        public static List<T> NonNull<T>(this List<T?> collection) where T : struct =>
            collection.Where(i => i.HasValue).Select(i => i!.Value).ToList();

        #endregion List

        #region Array

        public static T[] NonNull<T>(this T?[] collection) where T : class =>
            collection.Where(i => i != null).Select(i => i!).ToArray();

        public static T[] NonNull<T>(this T?[] collection) where T : struct =>
            collection.Where(i => i.HasValue).Select(i => i!.Value).ToArray();

        #endregion Array

        #region Set

        public static HashSet<T> NonNull<T>(this HashSet<T?> collection) where T : class =>
            collection.Where(i => i != null).Select(i => i!).ToHashSet();

        public static HashSet<T> NonNull<T>(this HashSet<T?> collection) where T : struct =>
            collection.Where(i => i.HasValue).Select(i => i!.Value).ToHashSet();

        #endregion Set

        #region Dictionary

        public static Dictionary<T, U> NonNull<T, U>(this Dictionary<T, U?> collection) where T : notnull where U : class =>
            collection.Where(kv => kv.Value != null).ToDictionary(kv => kv.Key, t => t.Value!);

        public static Dictionary<T, U> NonNull<T, U>(this Dictionary<T, U?> collection) where T : notnull where U : struct =>
            collection.Where(kv => kv.Value.HasValue).ToDictionary(kv => kv.Key, t => t.Value!.Value);

        #endregion Dictionary
    }
}