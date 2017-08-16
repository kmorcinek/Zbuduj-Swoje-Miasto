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
    }
}