using System;

namespace Functional
{
    public static partial class UnzipMaybe
    {
        public static Tuple<Maybe<T>, Maybe<K>> Unzip<T, K>(this Maybe<Tuple<T, K>> opt)
        {
            if (opt.IsNone())
            {
                return new Tuple<Maybe<T>, Maybe<K>>(Maybe<T>.None(), Maybe<K>.None());
            }

            return new Tuple<Maybe<T>, Maybe<K>>(Maybe<T>.Some(opt.Unwrap().Item1), Maybe<K>.Some(opt.Unwrap().Item2));
        }
    }
}