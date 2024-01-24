
namespace Functional
{
    public static partial class XOrMaybe
    {
        public static Maybe<T> XOr<T>(this Maybe<T> opt_a, Maybe<T> opt_b)
        {
            if (opt_a.IsNone() & opt_b.IsNone() | opt_a.IsSome() & opt_b.IsSome())
            {
                return Maybe<T>.None();
            }

            if (opt_a.IsSome())
            {
                return opt_a;
            }

            return opt_b;
        }
    }
}