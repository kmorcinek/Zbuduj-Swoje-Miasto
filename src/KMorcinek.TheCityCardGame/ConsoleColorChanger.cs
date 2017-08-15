using System;

namespace KMorcinek.TheCityCardGame
{
    public class ConsoleColorChanger : IDisposable
    {
        readonly ConsoleColor _previousColor;

        public ConsoleColorChanger(ConsoleColor newColor)
        {
            _previousColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
        }

        public void Dispose()
        {
            Console.ForegroundColor = _previousColor;
        }
    }
}