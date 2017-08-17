namespace KMorcinek.TheCityCardGame.ConsoleUI.Bots
{
    public class BotForWeb : Bot
    {
        public BotForWeb()
            : base(new GameServerWrapper())
        {
        }
    }
}