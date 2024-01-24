namespace Functional
{
    public static partial class OkOrMaybe
    {
        public static Result<T, E> OkOr<T, E>(this Maybe<T> opt, E err)
        {
            if (opt.IsNone())
            {
                return Result<T, E>.Err(err);
            }

            return Result<T, E>.Ok(opt.Unwrap());
        }
    }
}