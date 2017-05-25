using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquapark
{
    static class Program
    {
        public static int teller_id;
        public static string teller_name;
        public static string org_name;
        public static string org_unp;
        public static bool v = false;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]



        static void Main()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\Settings.ini");
                string[] st = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    st[i] = file.ReadLine();
                }
                file.Close();

            org_name = st[1];
            org_unp = st[2];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (st[0] == "Yes")
            {
                FirstStart n = new FirstStart();
                n.ShowDialog();
                Application.Run(new Form1());
            }
            if (st[0] == "No")
            {
                Login n = new Login();
                n.ShowDialog();
                Application.Run(new Form1());
            }
        }
    }
}
