using System;

namespace Functional
{
    public static class ApplyResult
    {
        public static Result<T, E> Apply<T, E>(this Result<T, E> res, Action<T> sub)
            => OnOkResult.OnOk(res, sub);
    }
}
