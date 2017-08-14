using System.Linq;
using FluentAssertions;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Can_play_Parking_card()
        {
            var player = new Player(new[] { Card.Parking });

            player.PlayCard(0, new int[0]);

            player.PlayedCards.Count().Should().Be(1);
            player.CardsInHand.Should().BeEmpty();
        } 

        [Fact]
        public void Can_play_House_card()
        {
            var player = new Player(new[] { Card.House, Card.House });

            player.PlayCard(0, new [] { 1 });

            player.PlayedCards.Count().Should().Be(1);
            player.CardsInHand.Should().BeEmpty();
        } 

    }
}