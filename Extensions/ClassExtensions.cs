using System;

namespace Jp.HelperExtensions
{
    public static class ClassExtensions
    {
        public static TResult Let<T, TResult>(this T value, Func<T, TResult> func) where T : class where TResult : class =>
            func.Invoke(value);

        public static void Run<T>(this T value, Action<T> action) where T : class => action.Invoke(value);
    }
}
