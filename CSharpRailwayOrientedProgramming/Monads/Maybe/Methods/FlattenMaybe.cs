namespace Functional
{
    public static class FlattenMaybe
    {
        public static Maybe<T> Flatten<T>(this Maybe<Maybe<T>> opt)
        {
            if (opt.IsNone())
            {
                return Maybe<T>.None();
            }

            return opt.Unwrap();
        }
    }
}
