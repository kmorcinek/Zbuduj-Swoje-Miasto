using System;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients;
using Serilog;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            EnableSerilog();

            PlayDisconnectedGame();
        }

        static void PlayDisconnectedGame()
        {
            // Wait couple second for Server to start
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();

            Task.Run(() =>
            {
                StartClient();
            });

            StartClient();
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
