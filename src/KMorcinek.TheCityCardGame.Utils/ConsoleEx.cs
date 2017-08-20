using System;

namespace KMorcinek.TheCityCardGame.Utils
{
    public static class ConsoleEx
    {
        /// <summary>
        /// Method the same as <see cref="Console.ReadLine"/> but turns null into empty string, so R# does not complain
        /// </summary>
        public static string ReadLine()
        {
            return Console.ReadLine() ?? "";
        }
    }
}