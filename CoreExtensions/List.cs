using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Contains extensions for IList
    /// </summary>
    public static class List
    {
        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are not overlapping. If the <paramref name="list"/> contains an odd amount of elements the second parameter has a default value (usually null) for the last iteration. Returns a new Iterator, that can be used for various things from IEnumerable interface. Example: [1,2,3,4,13,13].EachSlice().Where(tuple => tuple.Item1 != tuple.Item2).Select(tuple => tuple.Item1 + tuple.Item2); // [3,7]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<T, T>> EachSlice<T>(
            this IList<T> list)
        {
            for (int i = 0; i <= list.Count() - 1; i += 2)
                if (i <= list.Count() - 2)
                    yield return new Tuple<T, T>(list[i], list[i + 1]);
                else
                    yield return new Tuple<T, T>(list[i], default(T));
            yield break;
        }

        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are not overlapping and executes the <paramref name="action"/> for each pair. If the list contains an odd amount of elements the second parameter has a default value (usually null) for the last iteration. Example: [1,2,3,4].EachSlice((left, right) => Console.WriteLine(left+right)); //Write two lines "3" and "7"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action"></param>
        public static void EachSlice<T>(
            this IList<T> list, 
            Action<T, T> action)
        {
            foreach (var tuple in list.EachSlice())
            {
                action(tuple.Item1, tuple.Item2);
            }
        }

        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are not overlapping. If the list contains an odd amount of elements the second parameter has a default value (usually null) for the last iteration. It returns a new IEnumerable with the results of the evaluated <paramref name="function"/>. This can be used to chain more IEnumerable methods. Example: [1,2,3,4].EachSlice((left, right) => left + right).Select(n => n * 2);  // [6, 14]
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="list"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> EachSlice<TElement, TResult>(
            this IList<TElement> list,
            Func<TElement, TElement, TResult> function)
        {
            return list.EachSlice().Select(tuple => function(tuple.Item1, tuple.Item2));
        }

        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are overlapping. If the <paramref name="list"/> contains only one element the second parameter has a default value (usually null) for the one and only iteration. Returns a new Iterator, that can be used for various things from IEnumerable interface. Example: [1,2,3,4,13,13].EachColumn().Where(tuple => tuple.Item1 != tuple.Item2).Select(tuple => tuple.Item1 + tuple.Item2); // [3, 5, 7, 17]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<T, T>> EachColumn<T>(this IList<T> list)
        {
            switch(list.Count())
            {
                case 0:
                    yield break;
                case 1:
                    yield return new Tuple<T, T>(list[0], default(T));
                    break;
                default:
                    for (int i = 0; i <= list.Count() - 2; i += 1)
                        yield return new Tuple<T, T>(list[i], list[i + 1]);
                    break;
            }
            yield break;
        }

        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are overlapping. If the <paramref name="list"/> contains only one element the second parameter has a default value (usually null) for the one and only iteration. It returns a new IEnumerable with the results of the evaluated <paramref name="function"/>. This can be used to chain more IEnumerable methods. Example: [1,2,3,4].EachColumn((left, right) => left + right).Select(n => n * 2);  // [6, 10, 14]
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="list"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> EachColumn<TElement, TResult>(
            this IList<TElement> list,
            Func<TElement, TElement, TResult> function)
        {
            return list.EachColumn().Select(tuple => function(tuple.Item1, tuple.Item2));
        }

        /// <summary>
        /// Iterates over a <paramref name="list"/> in pairs, which are overlapping and executes the <paramref name="action"/> for each pair. If the <paramref name="list"/> contains only one element the second parameter has a default value (usually null) for the one and only iteration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void EachColumn<T>(
            this IList<T> list,
            Action<T, T> action)
        {
            foreach (var tuple in list.EachColumn())
            {
                action(tuple.Item1, tuple.Item2);
            }
        }
    }
}
