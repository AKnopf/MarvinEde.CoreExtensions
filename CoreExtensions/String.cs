namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class that holds all extension methods for <see cref="System.String"/>
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Returns true, if the <paramref name="string"/> is null, empty, "0" or "{}"
        /// </summary>
        /// <seealso cref="IsPresent(string)"/>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsBlank(this string @string)
        {
            return string.IsNullOrWhiteSpace(@string) || @string == "{}" || @string == "0";
        }

        /// <summary>
        /// Returns true, if the <paramref name="string"/> is not blank. 
        /// See: <see cref="String.IsBlank(string)"/>
        /// </summary>
        /// <seealso cref="IsBlank(string)"/>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsPresent(this string @string)
        {
            return !@string.IsBlank();
        }
    }
}
