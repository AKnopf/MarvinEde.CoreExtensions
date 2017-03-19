using System;
using System.Collections.Generic;
using System.Reflection;

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

        /// <summary>
        /// Finds an Enum value by its name. Ignores casing. Throws ArgumentException when T is not an enum
        /// 
        /// Example:
        /// <code>
        /// enum Fruit { Apple, Peach, Melon }
        /// "Apple".ToEnum&lt;Fruit&gt;() // Fruit.Apple
        /// "apple".ToEnum&lt;Fruit&gt;() // Fruit.Apple
        /// </code>
        /// 
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string description) where T : struct, IConvertible
        {
            Type type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T must be an enum");

            foreach (T values in Enum.GetValues(type))
            {
                FieldInfo field = type.GetField(Enum.GetName(type, values));
                if (string.Equals(description, Enum.GetName(type, values), StringComparison.OrdinalIgnoreCase))
                    return values;
            }
            return default(T);
        }

        /// <summary>
        /// Returns all enums where one of the international descriptions contains the given term.
        /// Default is case sensitive.
        /// </summary>
        public static IEnumerable<T> SearchEnum<T>(this string @string, bool ignoreCase = false) where T : struct, IConvertible
        {
            Type type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T must be an enum");

            foreach (T item in Enum.GetValues(type))
            {
                FieldInfo field = type.GetField(Enum.GetName(type, item));

                bool nameContainsTerm = ignoreCase
                        ? Enum.GetName(type, item).ToLower().Contains(@string.ToLower())
                        : Enum.GetName(type, item).Contains(@string);

                if (nameContainsTerm)
                    yield return item;
            }
            yield break;
        }
    }
}
