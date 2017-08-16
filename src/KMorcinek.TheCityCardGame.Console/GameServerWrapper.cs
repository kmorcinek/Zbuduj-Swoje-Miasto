﻿using RestSharp;

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