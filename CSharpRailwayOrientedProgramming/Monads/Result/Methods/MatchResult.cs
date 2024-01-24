using System;

namespace Functional
{
    public static class MatchResult
    {
        public static R Match<T, E, R>(this Result<T, E> result, Func<T, R> OnSuccess, Func<E, R> onError)
        {
            if (result.IsOk())
            {
                return OnSuccess(result.Unwrap());
            }
            return onError(result.Err());
        }

        public static void Match<T, E>(this Result<T, E> result, Action<T> OnSuccess, Action<E> onError)
        {
            if (result.IsOk())
            {
                OnSuccess(result.Unwrap());
            }
            else
            {
                onError(result.Err());
            }
        }
    }
}
