using System;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace KMorcinek.TheCityCardGame.Tests
{
    public class RequiredCardsCalculatorTests
    {
        [Fact]
        public void When_required_card_was_played_Then_CanBePlayed_returns_TRUE()
        {
            var sut = CreateSut();

            CardEnum requiredCardEnum = Fixture.Create<CardEnum>();
            Card requiredCard = new CardBuilder(requiredCardEnum);

            Player player = Player.CreateWithPlayedCards(requiredCard);

            Card cardToPlay = new CardBuilder(Fixture.Create<CardEnum>())
                .Requires(requiredCardEnum);

            sut.CanBePlayed(cardToPlay, player).Should().BeTrue();
        }

        [Fact]
        public void When_ANY_of_required_cards_was_played_Then_CanBePlayed_returns_TRUE()
        {
            var sut = CreateSut();

            CardEnum requiredCardEnum = Fixture.Create<CardEnum>();
            CardEnum differentRequiredCardEnum = GetDifferentRequiredCardEnum(requiredCardEnum);

            Card requiredCard = new CardBuilder(requiredCardEnum);

            Player player = Player.CreateWithPlayedCards(requiredCard);

            Card cardToPlay = new CardBuilder(Fixture.Create<CardEnum>())
                .Requires(requiredCardEnum, differentRequiredCardEnum);

            sut.CanBePlayed(cardToPlay, player).Should().BeTrue();
        }

        static CardEnum GetDifferentRequiredCardEnum(CardEnum requiredCardEnum)
        {
            CardEnum cardEnum;

            do
            {
                cardEnum = Fixture.Create<CardEnum>();
            } while (cardEnum == requiredCardEnum);

            return cardEnum;
        }

        [Fact]
        public void When_required_card_was_NOT_played_Then_CanBePlayed_returns_FALSE()
        {
            var sut = CreateSut();

            CardEnum requiredCardEnum = Fixture.Create<CardEnum>();

            Player player = Player.CreateWithPlayedCards();

            Card cardToPlay = new CardBuilder(Fixture.Create<CardEnum>())
                .Requires(requiredCardEnum);

            sut.CanBePlayed(cardToPlay, player).Should().BeFalse();
        }

        static RequiredCardsCalculator CreateSut()
        {
            return new RequiredCardsCalculator();
        }

        static readonly Fixture Fixture = new Fixture();
    }
}