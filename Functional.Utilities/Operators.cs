

namespace System
{
    public static class Operators
    {
        public static TResult Map<TSource, TResult>(
            this TSource @this,
            Func<TSource, TResult> operationToDo)
        {
            return operationToDo(@this);
        }

        public static void Tap<TSource>(
            this TSource @this,
            Action<TSource> operationToDo)
        {
            operationToDo(@this);
        }
    }
}
