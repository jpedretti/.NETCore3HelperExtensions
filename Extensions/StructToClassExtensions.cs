using System;

namespace RJPSoft.HelperExtensions
{
    public static class StructToClassExtensions
    {
        public static TResult Let<T, TResult>(this T value, Func<T, TResult> func) where T : struct where TResult : class =>
            func.Invoke(value);
    }
}
