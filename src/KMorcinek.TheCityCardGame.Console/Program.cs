using System;
using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var game = Game.Create();

            var board = game.StartGame();

            while (true)
            {
                ShowYourHand(board);

                var cardIndexToPlay = GetCardIndexToPlay();

                board = game.NextTurn(board, cardIndexToPlay); 
            }

            ShowYourHand(board);

            Console.ReadLine();
        }

        static int GetCardIndexToPlay()
        {
            string cardToPlayAsString = Console.ReadLine();

            int cardIndexToPlay = int.Parse(cardToPlayAsString);
            return cardIndexToPlay;
        }

        static void ShowYourHand(Board board)
        {
            Console.WriteLine();
            Console.WriteLine("Your Deck:");

            WriteCards(board.Player.CardsInHand);

            Console.WriteLine("Your Playedhand:");

            WriteCards(board.Player.PlayedCards);
        }

        static void WriteCards(IEnumerable<Card> playerCardsInHand)
        {
            foreach (var card in playerCardsInHand)
            {
                Console.WriteLine("\t" + card.CardEnum);
            }

            Console.WriteLine();
        }
    }
}
