using System;

namespace RJPSoft.HelperExtensions
{
    public static class StructExtensions
    {
        public static TResult Let<T, TResult>(this T value, Func<T, TResult> func) where T : struct where TResult : struct =>
            func.Invoke(value);

        public static void Run<T>(this T value, Action<T> action) where T : struct => action.Invoke(value);
    }
}
