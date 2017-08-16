namespace KMorcinek.TheCityCardGame.SharedDtos
{
    public class PlayCardDto
    {
        public int CardIndexToPlay { get; } 
        public int[] CardsToDiscard { get; }

        public PlayCardDto(int cardIndexToPlay, int[] cardsToDiscard)
        {
            CardIndexToPlay = cardIndexToPlay;
            CardsToDiscard = cardsToDiscard;
        }
    }
}