using System.Threading.Tasks;

namespace Functional
{
    public static partial class UnwrapOrMaybe
    {
        public static T UnwrapOr<T>(this Maybe<T> opt, T fallback)
        {
            if (opt.IsNone())
            {
                return fallback;
            }

            return opt.Unwrap();
        }
    }
}