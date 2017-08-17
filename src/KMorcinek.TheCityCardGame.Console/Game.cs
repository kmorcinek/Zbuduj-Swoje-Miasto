﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    public class Game
    {
        public static ConsoleColor[] Colors => new[]
        {
            ConsoleColor.Blue,
            ConsoleColor.White
        };

        public static void ShowPlayedCard(Card card)
        {
            Console.WriteLine($"\tPlayed card: {card.CardEnum}");
        }

        public static int GetCardIndexToPlay()
        {
            Console.Write("Choose card to play by index: ");

            string cardToPlayAsString = Console.ReadLine();

            return int.Parse(cardToPlayAsString);
        }

        public static int[] GetCardIndexesToDiscard()
        {
            Console.Write("Choose cards to discard by indices (separated by space): ");

            string asString = Console.ReadLine();

            string[] strings = asString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return strings.Select(int.Parse).ToArray();
        }

        public static void ShowCards(IPlayer player)
        {
            Console.WriteLine();
            Console.WriteLine("Your played cards:");

            WriteCards(player.PlayedCards);

            Console.WriteLine("\tPoints: " + player.Points);

            Console.WriteLine();
            Console.WriteLine("Cards in your hand:");

            WriteCards(player.CardsInHand);
        }

        public static void WriteCards(IEnumerable<Card> playerCardsInHand)
        {
            // TODO: add foreachWithIndex method
            int i = 0;
            foreach (var card in playerCardsInHand)
            {
                Console.WriteLine($"\t[{i}]{card.CardEnum} \t({card.Cost}, {card.CashPoints}, {card.WinPoints})");

                i++;
            }

            Console.WriteLine();
        }
    }
}