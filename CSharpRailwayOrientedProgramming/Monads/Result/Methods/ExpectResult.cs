using System;

namespace Functional
{
    public static class ExpectResult
    {
        public static T Expect<T, E>(this Result<T, E> res, string message)
        {
            if (res.IsOk()) 
            {
                return res.Unwrap();
            }

            throw new ExpectException(message);
        }
    }
}
