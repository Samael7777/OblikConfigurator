using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oblik;

namespace OblikConfigurator
{
    public static class Settings
    {
        public static SerialConnectionParams currentConnection = new SerialConnectionParams();
        public static int[] baudrates = 
            { 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200 };
        public enum Protocol
        {
            RS232,
            RS485,
            LAN,
        }
        public static Protocol protocol;
        public static void Initialize()
        {
            currentConnection.Address = 0x06;
            protocol = Protocol.RS485;
        }
        /// <summary>
        /// Состояние подключения
        /// </summary>
        public static bool isConnected = false;
    }
}
