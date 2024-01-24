using System;
using System.Threading.Tasks;

namespace Functional
{
    public static partial class MapMaybe
    {
        public static Maybe<K> Map<T, K>(this Maybe<T> opt, Func<T, K> _map)
        {
            if (opt.IsNone())
            {
                return Maybe<K>.None();
            }

            return Maybe<K>.Some(_map(opt.Unwrap()));
        }
    }
}