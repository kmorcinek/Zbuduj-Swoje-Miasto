using KMorcinek.TheCityCardGame.SharedDtos;
using RestSharp;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    public class GameServerWrapper : IGameServer
    {
        public const string ServerUrl = "http://localhost:7820/api/game";

        public int Connect()
        {
            var client = GetRestClient();
            var request = new RestRequest("connect", Method.GET);

            var response = client.Execute<int>(request);

            ThrowWhenEx(response);

            return response.Data;
        }

        public IPlayer GetState(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("state/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            var response = client.Execute<PlayerDto>(request);

            ThrowWhenEx(response);

            return response.Data;
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            var client = GetRestClient();

            var request = new RestRequest("play-card/{playerIndex}", Method.POST);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new PlayCardDto(cardIndexToPlay, cardsToDiscard));

            var response = client.Execute(request);

            ThrowWhenEx(response);
        }

        public void PlayArchitect(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("play-architect/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            var response = client.Execute(request);

            ThrowWhenEx(response);
        }

        public See5CardsDto See5Cards(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("see-5cards/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            var response = client.Execute<See5CardsDto>(request);

            ThrowWhenEx(response);

            return response.Data;
        }

        public void TakeOneCard(int playerIndex, CardEnum card)
        {
            var client = GetRestClient();

            var request = new RestRequest("take-one-card/{playerIndex}/{cardEnum}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());
            request.AddUrlSegment("cardEnum", ((int)card).ToString());

            var response = client.Execute(request);

            ThrowWhenEx(response);
        }

        static void ThrowWhenEx(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
        }

        static RestClient GetRestClient()
        {
            var client = new RestClient(ServerUrl);

            // Override with Newtonsoft JSON Handler
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);

            return client;
        }
    }
}