using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Can_DrawNewCards()
        {
            var player = Player.CreateWithPlayedCards(Card.House);
            var board = new Board(Deck.GetHardcodedDeck(), player);

            board.DrawNewCards(new CashPointsCalculator(), player);

            player.CardsInHand.Count().Should().Be(1);
        }

        [Fact]
        public void Cannot_draw_more_than_12_cards()
        {
            var player = new Player(Enumerable.Repeat(Card.House, 9).ToArray());
            var board = new Board(Deck.GetHardcodedDeck(), player);

            var calculator = new Mock<ICashPointsCalculator>();
            calculator
                .Setup(x => x.HowManyCashPoints(It.IsAny<IEnumerable<Card>>()))
                .Returns(11);

            board.DrawNewCards(calculator.Object, player);

            player.CardsInHand.Count().Should().Be(12);
        }
    }
}