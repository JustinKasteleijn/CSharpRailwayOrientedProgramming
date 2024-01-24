using System;

namespace Functional
{
    public readonly partial struct Result<T, E>
    {
        public static Result<T, E> Try(Func<T> func, Func<Exception, E> onExc)
        {
            try
            {
                return Ok(func());
            }
            catch (Exception ex)
            {
                return Err(onExc(ex));
            }
        }
    }
}