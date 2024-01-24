namespace Functional
{
    public static class SafeErrResult
    {
        public static Maybe<E> SafeErr<T, E>(this Result<T, E> res)
        {
            if (res.IsOk())
            {
                return Maybe<E>.None();
            }

            return Maybe<E>.Some(res.Err());
        }
    }
}
