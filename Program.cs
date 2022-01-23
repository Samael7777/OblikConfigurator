using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Oblik;


namespace OblikConfigurator
{
    /// <summary>
    /// статус соединения
    /// </summary>
    internal enum ConnectionStatus
    {
        OK,
        Wait,
        Error,
    }

    internal static class Program
    {
        //[DllImport("Shcore.dll")]
        //static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

        // According to https://msdn.microsoft.com/en-us/library/windows/desktop/dn280512(v=vs.85).aspx
        private enum DpiAwareness
        {
            None = 0,
            SystemAware = 1,
            PerMonitorAware = 2
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Настройка Hi DPI Scalling для Vista и выше
            if (Environment.OSVersion.Version.Major >= 6)
            { 
                //SetProcessDpiAwareness((int)DpiAwareness.PerMonitorAware);
            }
            Application.Run(new FormMain());
        }
    }
}
