using System;
using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame.Utils
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            var index = 0;
            foreach (var item in enumerable)
            {
                handler(item, index);
                index++;
            }
        }
    }
}