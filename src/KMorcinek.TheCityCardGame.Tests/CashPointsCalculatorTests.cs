using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class CashPointsCalculatorTests
    {
        [Fact]
        public void Can_Sum_simple_cash_points()
        {
            var sut = CreateSut();

            Card[] cards =
            {
                GetCardWithCashPoints(1),
                GetCardWithCashPoints(3)
            };

            sut.HowManyCashPoints(cards).Should().Be(4);
        }

        [Fact]
        public void CashPerOneCard_works()
        {
            var sut = CreateSut();

            CardEnum card = new Fixture().Create<CardEnum>();

            Card[] cards =
            {
                new CardBuilder(TestFixture.SimpleCard).ExtraCashPerOneCard(card, 5),
                new CardBuilder(card), 
            };

            sut.HowManyCashPoints(cards).Should().Be(5);
        }

        [Fact]
        public void When_two_obligatory_cards_for_CashPerOneCard_are_found_Then_only_bonus_is_added_only_once()
        {
            var sut = CreateSut();

            CardEnum card = new Fixture().Create<CardEnum>();

            Card[] cards =
            {
                new CardBuilder(TestFixture.SimpleCard).ExtraCashPerOneCard(card, 4),
                new CardBuilder(card), 
                new CardBuilder(card), 
            };

            sut.HowManyCashPoints(cards).Should().Be(4);
        }

        static CashPointsCalculator CreateSut()
        {
            var sut = new CashPointsCalculator();
            return sut;
        }

        static CardBuilder GetCardWithCashPoints(int cashPointsCount)
        {
            return new CardBuilder(TestFixture.SimpleCard, 0, cashPointsCount, 0);
        }

        class TestFixture
        {
            // Use it to avoid clashes with other features that add points based on cards already played
            public static CardEnum SimpleCard => CardEnum.House;
        }
    }
}