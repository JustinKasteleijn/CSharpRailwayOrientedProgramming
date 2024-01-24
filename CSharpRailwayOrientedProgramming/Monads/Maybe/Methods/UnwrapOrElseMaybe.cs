using System;
using System.Threading.Tasks;

namespace Functional
{
    public static partial class UnwrapOrElseType
    {
        public static T UnwrapOrElse<T>(this Maybe<T> opt, Func<T> fallback)
        {
            if (opt.IsNone())
            {
                return fallback();
            }

            return opt.Unwrap();
        }
    }
}