﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Static class to hold all extensions for <see cref="System.Object"/>, so they can be called from anywhere with "this."
    /// </summary>
    public static class Object
    {
        /// <summary>
        /// Swaps the two references a and b. This method handles the temporary variable for you.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="justForSyntax"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(this object justForSyntax, ref T a, ref T b)
        {
            T temp = b;
            b = a;
            a = temp;
        }

        /// <summary>
        /// Calls the action with the <paramref name="object"/> and then returns the <paramref name="object"/>. This can be useful for inline debugging or manipulating the object before calling other methods on it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T Tab<T>(this T @object, Action<T> action)
        {
            action(@object);
            return @object;
        }
    }
}
