using System;

namespace RJPSoft.HelperExtensions
{
    public static class ClassExtensions
    {
        public static TResult? Let<T, TResult>(this T? value, Func<T, TResult> func) where T : class where TResult : class =>
            value is T valueOfT ? func.Invoke(valueOfT) : null;

        public static void Run<T>(this T? value, Action<T> action) where T : class
        {
            if (value is T valueOfT)
            {
                action.Invoke(valueOfT);
            }
        }
    }
}
