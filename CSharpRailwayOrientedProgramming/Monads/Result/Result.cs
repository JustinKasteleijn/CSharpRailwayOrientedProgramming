
namespace Functional
{
    public readonly partial struct Result<T, E>
    {
        private readonly T _value;
        private readonly E _errorValue;
        private readonly bool _isSuccess;

        public Result(T value, E errorValue, bool isSuccess)
        {
            _value = value;
            _errorValue = errorValue;
            _isSuccess = isSuccess;
        }

        public bool IsErr()
        {
            return !_isSuccess;
        }

        public bool IsOk()
        {
            return _isSuccess;
        }

        public T Unwrap()
        {
            if (_isSuccess)
            {
                return _value;
            }
            throw new Panic("Result panicked at unwrap. Consider using 'result.Match' to also act upon the error if required");
        }

        public E Err()
        {
            if (!IsOk())
            {
                return _errorValue;
            }
            throw new Panic("Err panicked at err. Consider using 'result.match' to handle both succes and error case");
        }

        public static Result<T, E> Ok(T value)
        {
            return new Result<T, E>(value, default, true);
        }

        public static Result<T, E> Err(E errorValue)
        {
            return new Result<T, E>(default, errorValue, false);
        }
    }
}