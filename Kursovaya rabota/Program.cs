using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_rabota
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
            Application.Run(new Form1());
        }
    }
    class Database
    {
        public MySqlConnection cn;

        public void Connect()
        {
            cn = new MySqlConnection("Datasource=localhost; port=3308; username=root; password=; database= 184_yumayevko");
        }
    }
}
