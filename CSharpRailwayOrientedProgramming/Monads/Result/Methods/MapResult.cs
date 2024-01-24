using System;
using System.Net.Http;

namespace Functional
{
    public static class MapResult
    {
        public static Result<K, E> Map<T, K, E>(this Result<T, E> res, Func<T, K> func)
        {
            if (res.IsErr())
            {
                return Result<K, E>.Err(res.Err());
            }

            return Result<K, E>.Ok(func(res.Unwrap()));
        }
    }
}

