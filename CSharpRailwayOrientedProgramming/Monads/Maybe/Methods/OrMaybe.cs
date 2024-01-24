
namespace Functional
{
    public static partial class OrMaybe
    {
        public static Maybe<T> Or<T>(this Maybe<T> opt_a, Maybe<T> opt_b)
        {
            if (opt_a.IsSome())
            {
                return opt_a;
            }

            if (opt_b.IsSome())
            {
                return opt_b;
            }

            return Maybe<T>.None();
        }
    }
}