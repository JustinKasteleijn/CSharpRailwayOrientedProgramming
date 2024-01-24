using System;

namespace Functional
{
    public static class FlattenResult
    {
        public static Result<T, E> Flatten<T, E>(this Result<Result<T, E>, E> res)
        {
            if (res.IsErr())
            {
                return Result<T, E>.Err(res.Err());
            }

            return res.Unwrap();
        }
    }
}
