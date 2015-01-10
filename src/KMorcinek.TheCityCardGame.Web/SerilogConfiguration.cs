using Serilog;

namespace KMorcinek.TheCityCardGame.Web
{
    public static class SerilogConfiguration
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            Log.Information("WebApp started");
        }
    }
}