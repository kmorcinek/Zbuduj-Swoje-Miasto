using System;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    class Program
    {
        static void Main()
        {
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
    }
}
