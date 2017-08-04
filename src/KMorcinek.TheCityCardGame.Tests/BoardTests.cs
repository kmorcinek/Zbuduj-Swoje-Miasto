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
            var player = Player.CreateWithPlayedCards(Card.House);
            var board = new Board(Deck.GetShuffledDeck(), player);

            board.DrawNewCards(player);

            player.CardsInHand.Count().Should().Be(1);
        }
    }
}