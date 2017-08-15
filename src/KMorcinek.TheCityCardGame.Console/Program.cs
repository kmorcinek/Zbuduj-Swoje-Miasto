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
            Task.Run(() =>
            {
                StartClient();
            });

            StartClient();
        }

        static void StartClient()
        {
            var client = new DisconnectedClient();

            client.Start();
        }
    }
}
