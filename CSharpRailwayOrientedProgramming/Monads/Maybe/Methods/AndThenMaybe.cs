using System;

namespace Functional
{
    public static class AndThenMaybe
    {
        public static Maybe<K> AndThen<T, K>(this Maybe<T> opt, Func<T, Maybe<K>> func)
        {
            if (opt.IsNone())
            {
                return Maybe<K>.None();
            }

            return func(opt.Unwrap());
        }
    }
}
