using System;

namespace KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients
{
    public class ClientForWeb : DisconnectedClient
    {
        public ClientForWeb()
            : base(new GameServerWrapper(), TimeSpan.FromSeconds(1))
        {
        }
    }
}