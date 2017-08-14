using System.Linq;
using FluentAssertions;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Test()
        {
            var player = new Player(new[] { Card.Parking });

            player.PlayCard(0);

            player.PlayedCards.Count().Should().Be(1);
            player.CardsInHand.Should().BeEmpty();
        } 
    }
}