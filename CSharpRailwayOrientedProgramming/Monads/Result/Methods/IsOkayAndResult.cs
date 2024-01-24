using System;
using System.Runtime.InteropServices;

namespace Functional
{
    public static class IsOkAndResult
    {
        public static bool IsOkAnd<T, E>(this Result<T, E> res, Func<T, bool> predicate)
        {
            return res.IsOk()
                && predicate(res.Unwrap());
        }
    }
}
