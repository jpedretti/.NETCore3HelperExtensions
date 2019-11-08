using System;

namespace Jp.HelperExtensions
{
    public static class ClassToStructExtensions
    {
        public static TResult Let<T, TResult>(this T value, Func<T, TResult> func) where T : class where TResult : struct =>
            func.Invoke(value);
    }
}
