using System;
using System.Collections.Generic;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class that holds all extension methods for IDictionary
    /// </summary>
    public static class Dictionary
    {
        /// <summary>
        /// TODO
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
        /// TODO
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static TValue Fetch<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue @default = default(TValue))
        {
            var success = dict.TryGetValue(key, out TValue @out);
            return success ? @out : @default;
        }
    }
}
