using System;

namespace Functional
{
    public static class BindResult
    {
        public static Result<K, E> Bind<T, K, E>(this Result<T, E> res, Func<T, Result<K, E>> func)
            => AndThenResult.AndThen(res, func);
    }
}
