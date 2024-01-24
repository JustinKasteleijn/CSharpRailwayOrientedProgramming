using System;
using System.Threading.Tasks;

namespace Functional
{
    public static partial class MatchMaybe
    {
        public static K Match<T, K>(this Maybe<T> opt, Func<T, K> onSome, Func<K> onNone)
        {
            if (opt.IsNone())
            {
                return onNone();
            }

            return onSome(opt.Unwrap());
        }
    }
}