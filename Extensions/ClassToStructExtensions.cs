using System;

namespace RJPSoft.HelperExtensions
{
    public static class ClassToStructExtensions
    {
        public static TResult? Let<T, TResult>(this T? value, Func<T, TResult> func) where T : class where TResult : struct =>
            value is T valueOfT ? func.Invoke(valueOfT) : (TResult?)null;
    }
}
