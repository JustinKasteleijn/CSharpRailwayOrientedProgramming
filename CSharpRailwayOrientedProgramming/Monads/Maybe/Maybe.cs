
namespace Functional
{
    public readonly partial struct Maybe<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        private Maybe(bool hasValue, T value)
        {
            _hasValue = hasValue;
            _value = value;
        }

        public bool IsSome()
        {
            return _hasValue;
        }

        public bool IsNone()
        {
            return !_hasValue;
        }

        public T Unwrap()
        {
            if (!_hasValue)
            {
                throw new Panic($"Option panicked at unwrap on empty option");
            }
            return _value;
        }

        public static Maybe<T> Some(T value)
        {
            return new Maybe<T>(true, value);
        }

        public static Maybe<T> None()
        {
            return new Maybe<T>(false, default);
        }
    }
}