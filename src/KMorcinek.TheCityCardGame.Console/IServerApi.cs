using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.SharedDtos;
using Refit;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    public interface IServerApi
    {
        // TODO: Where to put /api/game
        [Get("/connect")]
        Task<int> Conntect();

        [Get("/state/{playerIndex}")]
        Task<PlayerDto> GetState(int playerIndex);

        [Post("/play-card/{playerIndex}")]
        Task PlayCard(int playerIndex, [Body] PlayCardDto playCardDto);

        [Get("/play-architect/{playerIndex}")]
        Task PlayArchitect(int playerIndex);

        [Get("/see-5cards/{playerIndex}")]
        Task<See5CardsDto> See5Cards(int playerIndex);

        [Get("/take-one-card/{playerIndex}/{card}")]
        Task TakeOneCard(int playerIndex, int card);

        [Get("/restart-server")]
        Task RestartServer();
    }
}