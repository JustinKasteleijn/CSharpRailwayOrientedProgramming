namespace Functional
{
    public static class AndMaybe
    {
        public static Maybe<K> And<T, K>(this Maybe<T> opt, Maybe<K> other)
        {
            if (opt.IsNone())
            {
                return Maybe<K>.None();
            }

            return other;
        }
    }
}
