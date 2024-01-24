using System;

namespace Functional
{
    public static class FinallyResult
    {
        public static T Finally<T, E>(this Result<T, E> res, Func<Result<T, E>, T> func)
        {
            return func(res);
        }
    }
}
