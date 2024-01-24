using System;

namespace Functional
{
    public static class InpsectMaybe
    {
        public static Maybe<T> Inspect<T>(this Maybe<T> opt, Action<string> printer)
        {
            if (opt.IsNone())
            {
                printer("Option is none");
            }
            else
            {
                printer($"Option contains value {opt.Unwrap()}");
            }

            return opt;
        }
    }
}
