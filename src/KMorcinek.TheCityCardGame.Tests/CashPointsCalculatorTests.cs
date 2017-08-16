using FluentAssertions;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class CashPointsCalculatorTests
    {
        [Fact]
        public void Can_Sum_simple_cash_points()
        {
            var sut = new CashPointsCalculator();

            Card[] cards =
            {
                GetCardWithCashPoints(1),
                GetCardWithCashPoints(3)
            };

            sut.HowManyCashPoints(cards).Should().Be(4);
        }

        static CardBuilder GetCardWithCashPoints(int cashPointsCount)
        {
            return new CardBuilder(Fixture.SimpleCard, 0, cashPointsCount, 0);
        }

        class Fixture
        {
            // Use it to avoid clashes with other features that add points based on cards already played
            public static CardEnum SimpleCard => CardEnum.House;
        }
    }
}