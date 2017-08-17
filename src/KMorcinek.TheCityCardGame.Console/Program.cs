using System;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients;
using RestSharp;
using Serilog;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EnableSerilog();

            bool restartGame = false;
            if (args != null && args.Length > 0 && args[0] == "--restart")
            {
                restartGame = true;
            }

            PlayDisconnectedGame(restartGame);
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

        static void EnableSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            Log.Information("App started");
        }
    }
}
