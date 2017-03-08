using System.Collections.Generic;
using System.Linq;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class that holds all extension methods for IEnumerable and IQueryable
    /// </summary>
    public static class Enumerable
    {
        /// <summary>
        /// Checks whether the <paramref name="object"/> is in the <paramref name="enumerable"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object">The object to look for</param>
        /// <param name="enumerable">The enumerable to look into</param>
        /// <returns>True if the object is in the enumerable, else False</returns>
        public static bool IsIn<T>(this T @object, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(@object);
        }

        /// <summary>
        /// Checks whether the <paramref name="object"/> is in the <paramref name="queryable"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object">The object to look for</param>
        /// <param name="queryable">The queryable to look into</param>
        /// <returns>True if the object is in the queryable, else False</returns>
        public static bool IsIn<T>(this T @object, IQueryable<T> queryable)
        {
            return queryable.Contains(@object);
        }

        /// <summary>
        /// Returns true, if the <paramref name="enumerable"/> is not empty.
        /// </summary>
        /// <seealso cref="Enumerable.IsBlank{T}(IEnumerable{T})"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsPresent<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any();
        }

        /// <summary>
        /// Returns true, if the <paramref name="queryable"/> is not empty.
        /// </summary>
        /// <seealso cref="IsBlank{T}(IQueryable{T})"/>I
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static bool IsPresent<T>(this IQueryable<T> queryable)
        {
            return queryable.Any();
        }

        /// <summary>
        /// Returns true, if the <paramref name="enumerable"/> is empty.
        /// </summary>
        /// <seealso cref="IsPresent{T}(IEnumerable{T})"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsBlank<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.IsPresent();
        }

        /// <summary>
        /// Return true, if the <paramref name="queryable"/> is empty.
        /// </summary>
        /// <seealso cref="IsPresent{T}(IQueryable{T})"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static bool IsBlank<T>(this IQueryable<T> queryable)
        {
            return !queryable.IsPresent();
        }
    }
}
