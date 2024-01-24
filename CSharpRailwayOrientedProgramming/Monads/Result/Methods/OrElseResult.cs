using System;

namespace Functional
{
    public static class OrElseResult
    {
        public static Result<T, E> OrElse<T, E>(this Result<T, E> res, Func<E, Result<T, E>> func)
        {
            if (res.IsErr())
            {
                return func(res.Err());
            }
            return res;
        }
    }
}

