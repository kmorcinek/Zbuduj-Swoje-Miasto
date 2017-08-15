using System;
using System.Collections.Generic;
using System.Linq;

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

            var cards = DrawStartingCards(wholeDeck);
            var player = new Player(cards);

            return new Board(wholeDeck, player);
        }

        static IEnumerable<Card> DrawStartingCards(Deck wholeDeck)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < 5; i++)
            {
                cards.Add(wholeDeck.Pop());
            }

            return cards;
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

        static int GetCardIndexToPlay()
        {
            Console.Write("Choose card to play by index: ");

            string cardToPlayAsString = Console.ReadLine();

            return int.Parse(cardToPlayAsString);
        }

        int[] GetCardIndexesToDiscard()
        {
            Console.Write("Choose cards to discard by indices (separated by space): ");

            string asString = Console.ReadLine();

            string[] strings = asString.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

            return strings.Select(int.Parse).ToArray();
        }

        static void ShowYourHand(Board board)
        {
            Console.WriteLine();
            Console.WriteLine("Your played cards:");

            WriteCards(board.Player.PlayedCards);

            Console.WriteLine("\tPoints: " + board.Player.Points);

            Console.WriteLine();
            Console.WriteLine("Cards in your hand:");

            WriteCards(board.Player.CardsInHand);

        }

        static void WriteCards(IEnumerable<Card> playerCardsInHand)
        {
            // TODO: add foreachWithIndex method

            int i = 0;
            foreach (var card in playerCardsInHand)
            {
                Console.WriteLine($"\t[{i}]{card.CardEnum} ({card.Cost})");

                i++;
            }

            Console.WriteLine();
        }
    }
}