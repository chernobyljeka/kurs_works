using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutukin
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        public static List<string> tmp = new List<string>();
        public static void read_bd(string sqlsrt, string pol)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='"+Application.StartupPath+@"\Кутукин1.accdb';OLE DB Services=-1";
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
            Application.Run(new Form1());
        }
    }
}
