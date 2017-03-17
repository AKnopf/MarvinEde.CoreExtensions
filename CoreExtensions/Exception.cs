namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class that holds all extension methods for <see cref="System.Exception"/>
    /// </summary>
    public static class Exception
    {
        /// <summary>
        /// Returns the innermost exception in case there are multiple levels of nested exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static System.Exception GetInnermostException(this System.Exception exception)
        {
            return exception.InnerException?.GetInnermostException() ?? exception;
        }

        /// <summary>
        /// Returns the first inner exception or the exception itself if it is <typeparamref name="T"/>. If none is found, null is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static T GetFirstInnerException<T>(this System.Exception exception) where T : System.Exception
        {
            if (exception is T found)
                return found;
            else
                return exception.InnerException?.GetFirstInnerException<T>();
        }

        /// <summary>
        /// Returns the innermost exception or the exception itself if it is <typeparamref name="T"/>. If none is found, null is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static T GetLastInnerException<T>(this System.Exception exception) where T : System.Exception
        {
            return exception.InnerException?.GetLastInnerException<T>() ?? exception as T;
        }
    }
}
