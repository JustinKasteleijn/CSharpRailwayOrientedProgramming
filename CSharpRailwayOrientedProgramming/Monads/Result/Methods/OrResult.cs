namespace Functional
{
    public static class OrResult
    {
        public static Result<T, E> Or<T, E>(this Result<T, E> res, Result<T, E> other)
        {
            if (res.IsOk())
            {
                return res;
            }
            return other;
        }
    }
}

