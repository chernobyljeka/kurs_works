using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DogsCenter;
using System.IO;

namespace DogsCenter
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static string way;
        public static bool splashscreen;
        public static int splashscreen_time;
        public static int counter = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            /// Чтение файла настроек
            System.IO.StreamReader file = new System.IO.StreamReader(@"Settings.ini");
            string[] st = new string[3];
            for (int i = 0; i < 3; i++)
            {
                st[i] = file.ReadLine();
            }
            file.Close();
            
            // Проверка корректности файла настроек и генерация нового файла
            if ((st[0] == "") || (st[0] == null) || (File.Exists(st[0]) == false) || (Path.GetExtension(st[0]) != ".txt")) { way = "database.txt"; }
            else
            {
                way = st[0];
            }
            
            try
            { splashscreen = Convert.ToBoolean(st[1]); }
            catch
            { splashscreen = false; }

            try
            { splashscreen_time = Convert.ToInt32(st[2]); }
            catch
            { splashscreen_time = 0; }
       

            if (splashscreen_time <= 0) { splashscreen = false; }

            StreamWriter SettingsFile = new StreamWriter("Settings.ini", false);
            SettingsFile.WriteLine(way);
            SettingsFile.WriteLine(splashscreen);
            SettingsFile.WriteLine(splashscreen_time);
            SettingsFile.Close();
            if (File.Exists(st[0]) == false) { File.Create("database.txt"); };
                if ((splashscreen_time <= 0) || (splashscreen == false))
                {
                    Application.Run(new Form1());
                }
                else
                {
                    Application.Run(new DogsCenterSplashScreen());
                }

            }
        }
    }