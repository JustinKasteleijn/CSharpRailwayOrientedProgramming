using System.Runtime.CompilerServices;

namespace Functional
{
    public static class UnwrapOrResult
    {
        public static T UnwrapOr<T, E>(this Result<T, E> res, T or)
        {
            if (res.IsErr())
            {
                return or;
            }

            return res.Unwrap();
        }
    }
}
