using System;

namespace RJPSoft.HelperExtensions
{
    public static class StructExtensions
    {
        public static TResult? Let<T, TResult>(this T? value, Func<T, TResult> func) where T : struct where TResult : struct =>
            value is T valueOfT ? func.Invoke(valueOfT) : (TResult?)null;

        public static void Run<T>(this T value, Action<T> action) where T : struct 
        {
            if (value is T valueOfT)
            {
                action.Invoke(valueOfT);
            }
        }
    }
}
