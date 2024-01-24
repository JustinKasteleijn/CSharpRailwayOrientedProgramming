using System;

namespace Functional
{
    public static class OnOkResult
    {
        public static Result<T, E> OnOk<T, E>(this Result<T, E> res, Action<T> func)
        {
            if (res.IsOk())
            {
                func(res.Unwrap());
            }
            return res;
        }
    }
}

