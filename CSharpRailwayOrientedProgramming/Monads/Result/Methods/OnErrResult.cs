using System;

namespace Functional
{
    public static class OnErrResult
    {
        public static Result<T, E> OnErr<T, E>(this Result<T, E> res, Action<E> func)
        {
            if (res.IsErr())
            {
                func(res.Err());
            }
            return res;
        }
    }
}

