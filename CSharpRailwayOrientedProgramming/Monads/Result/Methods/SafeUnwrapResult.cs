namespace Functional
{
    public static class SafeUnwrapResult
    {
        public static Maybe<T> SafeUnwrap<T, E>(this Result<T, E> res)
        {
            if (res.IsErr())
            {
                return Maybe<T>.None();
            }

            return Maybe<T>.Some(res.Unwrap());
        }
    }
}
