using Oblik;
using Oblik.Driver;

namespace OblikConfigurator
{
    public static class Settings
    {
        public static ConnectionParams connectionParams = new ConnectionParams()
        {
            Address = 0x06,
            User = UserLevel.Energo,
            Password = ""
        };

        public static IOblikDriver oblikDriver;

        public static Meter Oblik;

        public static int[] baudrates =
            { 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200 };

        /// <summary>
        /// Состояние подключения
        /// </summary>
        public static bool isConnected = false;

        public static int Repeats = 3;
    }
}