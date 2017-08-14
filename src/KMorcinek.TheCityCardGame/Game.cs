using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Game
    {
        private readonly Calculator _calculator;

        public static Game Create()
        {
            return new Game(null);
        }

        public Game(Calculator calculator)
        {
            _calculator = calculator;
        }

        Board StartGame()
        {
            var wholeDeck = Deck.GetShuffledDeck();
            var player = new Player(new[] { Card.Parking });

            // TODO: Board should not take wholeDeck
            var board = new Board(player, wholeDeck);
            return board;
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