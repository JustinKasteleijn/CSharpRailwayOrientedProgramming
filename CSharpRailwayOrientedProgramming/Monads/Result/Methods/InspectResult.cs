using System;

namespace Functional
{
    public static class InspectResult
    {
        public static Result<T, E> Inspect<T, E>(this Result<T, E> res, Action<string> printer)
        {
            if (res.IsErr())
            {
                printer($"Result contains error of: {res.Err()}");
            }
            else
            {
                printer($"Result contains value of: {res.Unwrap()}");
            }
            return res;
        }
    }
}
