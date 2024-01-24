namespace Functional
{
    public static class ExpectMaybe
    {
        public static T Expect<T>(this Maybe<T> opt, string message)
        {
            if (opt.IsNone())
            {
                throw new ExpectException(message);
            }

            return opt.Unwrap();
        }
    }
}
