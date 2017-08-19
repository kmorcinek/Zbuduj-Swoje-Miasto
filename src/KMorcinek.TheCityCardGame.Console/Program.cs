using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.Bots;
using KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients;
using RestSharp;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SerilogConfiguration.Configure();

            bool isBotSetting = IsSetting(args, "--bot");

            if (isBotSetting)
            {
                PlayBots();
                return;
            }

            bool restartGame = IsSetting(args, "--restart");

            PlayDisconnectedGame(restartGame);
        }

        static bool IsSetting(string[] args, string switchName)
        {
            return args != null && args.Length > 0 && args[0] == switchName;
        }

        static void PlayBots()
        {
            List<int> turns = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                var client = new Bot();

                int turn = client.Start();

                turns.Add(turn);
            }

            Console.WriteLine($"Average: {turns.Average()}");

            Console.ReadLine();
        }

        static void PlayDisconnectedGame(bool restartGame)
        {
            // Wait couple second for Server to start
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();

            if (restartGame)
            {
                RestartServer();
            }

            if (DisconnectedGame.TotalPlayersCount == 2)
            {
                Task.Run(() =>
                {
                    StartClient();
                });
            }

            StartClient();

            Console.ReadLine();
        }

        static void RestartServer()
        {
            // HACK: I have problems with debugging, so best is to always restart server explicit
            var client = new RestClient(GameServerWrapper.ServerUrl);
            var request = new RestRequest("restart-server", Method.GET);

            client.Execute(request);
        }

        static void StartClient()
        {
            var client = new ClientForWeb();

            client.Start();
        }
    }
}
