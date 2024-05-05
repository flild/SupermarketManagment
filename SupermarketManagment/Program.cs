using SupermarketManagment.Scripts.Cashier;
using SupermarketManagment.Scripts.User;
using System;
using System.Windows.Forms;

namespace SupermarketManagment
{
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
            Application.Run(new Login());
        }
    }
}
