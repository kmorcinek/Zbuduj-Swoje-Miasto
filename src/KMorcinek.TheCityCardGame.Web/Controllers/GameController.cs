using System.Web.Http;

namespace KMorcinek.TheCityCardGame.Web.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        readonly DisconnectedGame _game = DisconnectedGame.Instance;

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
    }
}