using System.Web.Http;

namespace KMorcinek.TheCityCardGame.Web.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        static DisconnectedGame _game = DisconnectedGame.Instance;

        [Route("connect")]
        public int GetConnect()
        {
            return _game.Connect();
        }

        [Route("state/{playerIndex}")]
        public PlayerDto GetState(int playerIndex)
        {
            return _game.GetState(playerIndex) as PlayerDto;
        }

        // HACK: I have problems with debugging, so best is to always restart server explicit
        [HttpGet]
        [Route("restart-server")]
        public void RestartServer()
        {
            _game = new DisconnectedGame();
        }
    }
}