using System;

namespace Functional
{
    public static class AssertResult
    {
        public static Result<T, E> Assert<T, E>(this Result<T, E> res, Func<T, bool> predicate, Func<T, E> errorHandler)
        {
            if (res.IsErr())
            { 
                return res; 
            }

            if (!predicate(res.Unwrap()))
            {
                return Result<T, E>.Err(errorHandler(res.Unwrap()));
            }

            return res;
        }
    }
}
