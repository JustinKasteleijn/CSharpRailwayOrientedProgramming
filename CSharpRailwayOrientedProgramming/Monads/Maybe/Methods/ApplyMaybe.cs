using System;

namespace Functional
{
    public static class ApplyMaybe
    {
        public static Maybe<T> Apply<T>(this Maybe<T> opt, Action<T> sub)
        {
            if (opt.IsSome())
            {
                sub(opt.Unwrap());
            }

            return opt;
        }
    }
}
