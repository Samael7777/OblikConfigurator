using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oblik;

namespace OblikConfigurator
{
    public static class Settings
    {
        public static ConnectionParams currentConnection = new ConnectionParams();
        public static int[] baudrates = 
            { 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200 };
        public static void Initialize()
        {

        }
    }
}
