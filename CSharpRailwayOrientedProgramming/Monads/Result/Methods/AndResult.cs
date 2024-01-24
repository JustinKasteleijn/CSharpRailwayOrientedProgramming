namespace Functional
{
    public static class AndResult
    {
        public static Result<K, E> And<T, K, E>(this Result<T, E> res, Result<K, E> other)
        {
            if (res.IsErr() && other.IsErr() || res.IsOk() && other.IsOk())
            {
                return other;
            }

            if (res.IsErr())
            {
                return Result<K, E>.Err(res.Err());
            }

            return other;
        }
    }
}
