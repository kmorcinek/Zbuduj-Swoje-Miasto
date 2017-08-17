using System.Web.Http;
using KMorcinek.TheCityCardGame.SharedDtos;
using Serilog;

namespace KMorcinek.TheCityCardGame.Web.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        // HACK: I have problems with debugging, so best is to always restart server explicit and this is static
        static DisconnectedGame _game = DisconnectedGame.Instance;

        [Route("connect")]
        public int GetConnect()
        {
            int playerIndex = _game.Connect();

            Log.Debug("GetConnect returns {playerIndex}", playerIndex);

            return playerIndex;
        }

        [Route("state/{playerIndex}")]
        public PlayerDto GetState(int playerIndex)
        {
            Log.Debug("GameController.GetState({playerIndex})", playerIndex);
            return _game.GetState(playerIndex) as PlayerDto;
        }

        [HttpPost]
        [Route("play-card/{playerIndex}")]
        public void PlayCard(int playerIndex, [FromBody]PlayCardDto playCardDto)
        {
            Log.Debug("GameController.PlayCard()");
            _game.PlayCard(playerIndex, playCardDto.CardIndexToPlay, playCardDto.CardsToDiscard);
        }

        [Route("play-architect/{playerIndex}")]
        public void GetPlayArchitect(int playerIndex)
        {
            Log.Debug("GameController.GetPlayArchitect()");
            _game.PlayArchitect(playerIndex);
        }

        // HACK: I have problems with debugging, so best is to always restart server explicit
        [HttpGet]
        [Route("restart-server")]
        public void GetRestartServer()
        {
            Log.Debug("GameController.RestartServer");
            _game = new DisconnectedGame();
        }
    }
}