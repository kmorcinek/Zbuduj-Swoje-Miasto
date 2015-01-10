using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class WinningPointsCalculatorTests
    {
        [Fact]
        public void When_Symbol_is_found_on_more_cards()
        {
            var sut = CreateSut();

            Symbol symbol = new Fixture().Create<Symbol>();

            int result = sut.Calculate(
                new Card[]
                {
                    CreateNewGenericCardBuilder().WithSymbols(symbol).ExtraWinPoints(symbol),
                    CreateNewGenericCardBuilder().WithSymbols(symbol)
                });

            result.Should().Be(2);
        }

        [Fact]
        public void When_Three_Symbols_are_found_on_one_card()
        {
            var sut = CreateSut();

            Symbol symbol = new Fixture().Create<Symbol>();

            int result = sut.Calculate(
                new Card[]
                {
                    CreateNewGenericCardBuilder().ExtraWinPoints(symbol),
                    CreateNewGenericCardBuilder().WithSymbols(Enumerable.Repeat(symbol, 3).ToArray())
                });

            result.Should().Be(3);
        }

        static CardBuilder CreateNewGenericCardBuilder()
        {
            return new CardBuilder(CardEnum.House, 0, 0, 0);
        }

        static WinningPointsCalculator CreateSut()
        {
            return new WinningPointsCalculator();
        }
    }
}