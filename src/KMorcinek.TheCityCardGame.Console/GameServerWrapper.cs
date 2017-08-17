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

            return client.Execute<int>(request).Data;
        }

        public IPlayer GetState(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("state/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            return client.Execute<PlayerDto>(request).Data;
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            var client = GetRestClient();

            var request = new RestRequest("play-card/{playerIndex}", Method.POST);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new PlayCardDto(cardIndexToPlay, cardsToDiscard));

            client.Execute(request);
        }

        public void PlayArchitect(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("play-architect/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            client.Execute(request);
        }

        public See5CardsDto See5Cards(int playerIndex)
        {
            var client = GetRestClient();

            var request = new RestRequest("see-5cards/{playerIndex}", Method.GET);
            request.AddUrlSegment("playerIndex", playerIndex.ToString());

            return client.Execute<See5CardsDto>(request).Data;
        }

        public void TakeOneCard(int playerIndex, CardEnum card)
        {
            throw new System.NotImplementedException();
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