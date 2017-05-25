using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class AddTeller : Form
    {
        public AddTeller()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public bool edit = false;

        private bool validate_form()
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
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

        private string PHash;

        private void load_info()
        {
            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"Select Login, PashHash From Tellers Where ID_teller = " + Program.teller_id + ";";
            var dr = DB.com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox4.Text = dr[0].ToString();
                    PHash = dr[1].ToString();
                }
                dr.Close();
            }
            DB.con.Close();
            textBox4.Enabled = false;
            textBox3.Text = Program.teller_name;
            label5.Text = "Старый пароль";
            label1.Text = "Новый пароль";
        }

        private void AddTellerDB()
        {
            if (textBox1.Text == textBox5.Text)
            {
                DB.com.Connection = DB.con;
                DB.com.CommandText = @"INSERT INTO Tellers Values ('"
                                       + textBox3.Text + "','"
                                       + textBox4.Text + "','"
                                       + HashMD5(textBox5.Text) + "');";
                DB.con.Open();
                DB.com.ExecuteNonQuery();
                DB.con.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpDateTellerDB()
        {
            if (HashMD5(textBox5.Text) == PHash)
            {
                DB.com.Connection = DB.con;
                DB.com.CommandText = @"UPDATE Tellers SET "
                              + "FIO = '" + textBox3.Text
                              + "', Login = '" + textBox4.Text
                              + "', PashHash = '" + HashMD5(textBox1.Text)
                              + "' Where ID_Teller = " + Program.teller_id + ";";
                Program.teller_name = textBox3.Text;
                DB.con.Open();
                DB.com.ExecuteNonQuery();
                DB.con.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Старый пароль введен неверно!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validate_form())
                if (edit) UpDateTellerDB();
                else AddTellerDB();        
        }

        private void AddTeller_Load(object sender, EventArgs e)
        {
            if (edit) load_info();
        }
    }
}
