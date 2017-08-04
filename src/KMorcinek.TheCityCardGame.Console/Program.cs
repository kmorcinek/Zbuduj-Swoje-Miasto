using System;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var game = Game.Create();

            var board = game.StartGame();

            Console.WriteLine("Your Deck:");

            foreach (var card in board.Player.CardsInHand)
            {
                Console.WriteLine(card.CardEnum.ToString()); 
            }

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
