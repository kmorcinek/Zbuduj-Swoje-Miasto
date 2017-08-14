using System;
using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class Game
    {
        public static Game Create()
        {
            return new Game();
        }

        Board StartGame()
        {
            var wholeDeck = Deck.GetShuffledDeck();
            var player = new Player(new[] { Card.Parking });

            return new Board(player, wholeDeck);
        }

        public void PlayGame()
        {
            var board = StartGame();

            while (true)
            {
                ShowYourHand(board);

                var cardIndexToPlay = GetCardIndexToPlay();
                int[] cardsToDiscard = GetCardIndexesToDiscard();

                board.NextTurn(cardIndexToPlay, cardsToDiscard);
            }

            ShowYourHand(board);

            Console.ReadLine();
        }

        int[] GetCardIndexesToDiscard()
        {
            throw new NotImplementedException();
        }

        static int GetCardIndexToPlay()
        {
            string cardToPlayAsString = Console.ReadLine();

            return int.Parse(cardToPlayAsString);
        }

        static void ShowYourHand(Board board)
        {
            Console.WriteLine();
            Console.WriteLine("Your Deck:");

            WriteCards(board.Player.CardsInHand);

            Console.WriteLine("Your Playedhand:");

            WriteCards(board.Player.PlayedCards);

            Console.WriteLine("\tPoints: " + board.Player.Points);
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