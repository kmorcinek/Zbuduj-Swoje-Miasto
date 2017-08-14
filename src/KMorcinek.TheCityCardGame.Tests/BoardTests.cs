using System.Linq;
using FluentAssertions;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Can_DrawNewCards()
        {
            var player = Player.CreateWithPlayedCards(new[] { Card.House });
            var board = new Board(player, Deck.GetShuffledDeck());

            board.DrawNewCards(player);

            player.CardsInHand.Count().Should().Be(1);
        }
    }
}