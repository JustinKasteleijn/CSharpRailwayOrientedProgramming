using System;

namespace Functional
{
    public static class FilterMaybe
    {
        public static Maybe<T> Filter<T>(this Maybe<T> opt, Func<T, bool> predicate)
        {
            if (opt.IsNone())
            {
                return opt;
            }

            if (predicate(opt.Unwrap()))
            {
                return opt;
            }

            return Maybe<T>.None();
        }
    }
}
