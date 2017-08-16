using System.Web.Http;

namespace KMorcinek.TheCityCardGame.Web.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        [Route("connect")]
        public int GetConnect()
        {
            return 0;
        }
    }
}