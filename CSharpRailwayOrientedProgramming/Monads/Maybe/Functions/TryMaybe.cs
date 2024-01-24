using System;

namespace Functional
{
    public readonly partial struct Maybe<T>
    {
        public static Maybe<K> Try<K>(Func<K> func)
        {
            try {
                return Maybe<K>.Some(func());
            } catch (Exception)
            {
                return Maybe<K>.None();
            }
        }
    }
}