using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    // ReSharper disable once InconsistentNaming
    public class CashPointsCalculatorTests_CalculateCashPerSymbol
    {
        [Fact]
        public void Test()
        {
            Symbol symbol = new Fixture().Create<Symbol>();

            int result = CashPointsCalculator.CalculateCashPerSymbol(
                new Card[]
                {
                    CreateNewGenericCardBuilder().ExtraCashPoints(symbol),
                    CreateNewGenericCardBuilder().WithSymbols(symbol, symbol),
                    CreateNewGenericCardBuilder().WithSymbols(symbol)
                });

            result.Should().Be(3);
        }

        static CardBuilder CreateNewGenericCardBuilder()
        {
            return new CardBuilder(CardEnum.House, 0, 0, 0);
        }
    }
}