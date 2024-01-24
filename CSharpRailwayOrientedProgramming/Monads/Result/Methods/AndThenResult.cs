using System;

namespace Functional
{
    public static class AndThenResult
    {
        public static Result<K, E> AndThen<T, K, E>(this Result<T, E> res, Func<T, Result<K, E>> func)
        {
            if (res.IsErr())
            {
                return Result<K, E>.Err(res.Err());
            }

            return func(res.Unwrap());
        }
    }
}
