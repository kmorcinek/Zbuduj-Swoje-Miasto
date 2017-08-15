﻿using System;
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
            Deck wholeDeck = Deck.GetShuffledDeck();

            Player player = new Player(DrawStartingCards(wholeDeck));
            Player secondPlayer = new Player(DrawStartingCards(wholeDeck));

            return new Board(wholeDeck, player, secondPlayer);
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
                ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.White };

                for (int i = 0; i < board.Players.Count(); i++)
                {
                    using (new ConsoleColorChanger(colors[i]))
                    {
                        ShowCards(board.Players.ElementAt(i));

                        var cardIndexToPlay = GetCardIndexToPlay();
                        int[] cardsToDiscard = GetCardIndexesToDiscard();

                        board.PlayCard(i, cardIndexToPlay, cardsToDiscard);
                    }
                }
            }
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

        static void ShowCards(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Your played cards:");

            WriteCards(player.PlayedCards);

            Console.WriteLine("\tPoints: " + player.Points);

            Console.WriteLine();
            Console.WriteLine("Cards in your hand:");

            WriteCards(player.CardsInHand);
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