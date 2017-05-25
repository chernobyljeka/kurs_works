using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TimeTable_GGAEK_v1._0
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary> 

        public static List<string> tmp = new List<string>();
        public static void read_bd(string sqlsrt, string pol)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\TimetableGGAEK.accdb';OLE DB Services=-1";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = sqlsrt;
            command.Connection = connection;
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tmp.Add(dr[pol].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
            finally
            {
                connection.Close();
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
