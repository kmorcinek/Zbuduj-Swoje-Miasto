using System.Linq;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class CardsDealerTests
    {
        private readonly CardsDealer _cardsDealer;

        public CardsDealerTests()
        {
            _cardsDealer = new CardsDealer();
        }

        [Fact]
        public void Test1()
        {
            // "With Pattern" from Ultrico.
            var board = new Board(new Player(Enumerable.Empty<Card>(), new[]
            {
                new Card(0, 0, 1, 0),
            }),
                new[]
                {
                    Card.Wohnhaus,
                    Card.Wohnhaus
                });

            var result = _cardsDealer.DealNewCards(board);

            Assert.Equal(1, result.Deck.Count());
            Assert.Equal(1, result.Player.CardsInHand.Count());
        }
    }
}