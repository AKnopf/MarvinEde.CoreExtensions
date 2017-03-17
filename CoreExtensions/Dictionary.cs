using System;
using System.Collections.Generic;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class that holds all extension methods for <see cref="System.Collections.IDictionary"/>
    /// </summary>
    public static class Dictionary
    {
        /// <summary>
        /// Tries to get the value for the given <paramref name="key"/> and calls the given <paramref name="default"/> function, to get the default value if failing to do so. This is handy when calculating the default value is expensive, since the function is called lazyly.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static TValue Fetch<TKey,TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue> @default)
        {
            var success = dict.TryGetValue(key, out TValue @out);
            return success ? @out : @default();
        }

        /// <summary>
        /// Tries to get the value for the given <paramref name="key"/> and returns the given <paramref name="default"/> if failing to do so.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="default">Defaults to default(TKey). (Usually null)</param>
        /// <returns></returns>
        public static TValue Fetch<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue @default = default(TValue))
        {
            var success = dict.TryGetValue(key, out TValue @out);
            return success ? @out : @default;
        }
    }
}
