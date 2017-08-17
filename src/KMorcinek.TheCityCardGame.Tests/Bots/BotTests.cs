using FluentAssertions;
using KMorcinek.TheCityCardGame.ConsoleUI.Bots;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests.Bots
{
    public class BotTests
    {
        [Fact]
        public void GetCardsToDiscard_works()
        {
            int[] cardsToDiscard = Bot.GetCardsToDiscard(3, 1);

            cardsToDiscard.Should().BeEquivalentTo(new[] { 0, 2, 3 } );
        }
    }
}