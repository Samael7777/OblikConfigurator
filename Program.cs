using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
