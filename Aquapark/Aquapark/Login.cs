using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string HashMD5(string Source)
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
            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"Select * From Tellers Where Login like '" + textBox1.Text + "';";
            var dr = DB.com.ExecuteReader();
            string pashash = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Program.teller_id = (int)dr[0];
                    Program.teller_name = dr[1].ToString();
                    pashash = dr[3].ToString();
                }
                dr.Close();
            }
            DB.con.Close();

            if (pashash == HashMD5(textBox2.Text))
            {
                Program.v = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный пароль или логин.\nИли отсутвует соедениение с базой данных", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.v == false)
            {
                Application.Exit();
            }
        }

        private void Login_Enter(object sender, EventArgs e)
        {
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }
    }
}
