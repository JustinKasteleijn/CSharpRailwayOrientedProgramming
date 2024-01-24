using System;
using System.Runtime.InteropServices;

namespace Functional
{
    public static class IsErrAndResult
    {
        public static bool IsErrAnd<T, E>(this Result<T, E> res, Func<E, bool> predicate)
        {
            return !res.IsOk()
                && predicate(res.Err());
        }
    }
}
