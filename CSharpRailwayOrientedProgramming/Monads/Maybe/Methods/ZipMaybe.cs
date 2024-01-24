using System;
using System.Threading.Tasks;

namespace Functional
{
    public static partial class ZipMaybe
    {
        public static Maybe<Tuple<T, K>> Zip<T, K>(this Maybe<T> opt, Maybe<K> other)
        {
            if (opt.IsNone() | other.IsNone())
            {
                return Maybe<Tuple<T, K>>.None();
            }

            return Maybe<Tuple<T, K>>.Some(new Tuple<T, K>(opt.Unwrap(), other.Unwrap()));
        }
    }
}