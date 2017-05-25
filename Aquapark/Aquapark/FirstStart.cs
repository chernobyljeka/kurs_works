using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class FirstStart : Form
    {
        public FirstStart()
        {
            InitializeComponent();
        }

        private void FirstStart_Load(object sender, EventArgs e)
        {

        }

        private bool form_validate()
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private int get_last_teller()
        {
            int last_client = 0;
            try
            {
                DB.com.Connection = DB.con;
                DB.con.Open();
                DB.com.CommandText = @"Select MAX(ID_teller) From Tellers";
                var dr = DB.com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        last_client = Convert.ToInt32(dr[0]);
                    }
                    dr.Close();
                }
                DB.con.Close();
            }
            catch
            {
                DB.con.Close();
            }
            return last_client;
        }

        static string HashMD5(string Source)
        {
            byte[] hash = Encoding.ASCII.GetBytes(Source);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (form_validate())
            {
                Program.org_name = textBox1.Text;
                Program.org_unp = textBox2.Text;

                using (System.IO.StreamWriter file =
                          new System.IO.StreamWriter(Application.StartupPath
                              + @"\Settings.ini", false))
                {
                    file.WriteLine("No");
                    file.WriteLine(textBox1.Text);
                    file.WriteLine(textBox2.Text);
                    file.Close();
                }

                Program.teller_name = textBox3.Text;
                Program.teller_id = get_last_teller() + 1;

                DB.com.Connection = DB.con;
                DB.com.CommandText = @"INSERT INTO Tellers Values ('"
                                       + textBox3.Text + "','"
                                       + textBox4.Text + "','"
                                       + HashMD5(textBox5.Text) + "');";
                DB.con.Open();
                DB.com.ExecuteNonQuery();
                DB.con.Close();
                Program.v = true;
                Close();
            }
        }

        private void FirstStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.v == false)
            {
                Application.Exit();
            }
        }
    }
}
