using System;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class Add_EditForm : Form
    {
        public Add_EditForm()
        {
            InitializeComponent();
        }

        public bool edit;
        public int id_clinet;
        public string n_client;
        public string f_client;
        public string r_client;
        public DateTime d_client;

        #region "Пользовательские методы"

        private bool validate_form()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите ФИО!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        private int get_last_client()
        {
            int last_client = 0;
            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"Select MAX(ID_Client) From Clients";
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
            return last_client;
        }

        private void benefits(int client_id, byte bef_id)
        {
            DB.com.Connection = DB.con;

            DB.com.CommandText = @"INSERT INTO Privileges Values ('"
                                   + client_id + "','"
                                   + bef_id + "');";
            DB.con.Open();
            DB.com.ExecuteNonQuery();
            DB.con.Close();
        }

        private void Add()
        {
            var d = dateTimePicker1.Value;
            DB.com.Connection = DB.con;

            DB.com.CommandText = @"INSERT INTO Clients Values ('"
                                   + textBox1.Text + "','" 
                                   + textBox2.Text + "','"
                                   + textBox3.Text + "', '"
                                   + d.ToString("dd.MM.yyyy") +"');";
            DB.con.Open();
            DB.com.ExecuteNonQuery();
            DB.con.Close();

            if (checkBox1.Checked == true)
            {
                benefits(get_last_client(), 1);
            }
            if (checkBox2.Checked == true)
            {
                benefits(get_last_client(), 2);
            }
            if (checkBox3.Checked == true)
            {
                benefits(get_last_client(), 3);
            }
            if (checkBox4.Checked == true)
            {
                benefits(get_last_client(), 4);
            }

            this.Close();
        }



        private void Edit()
        {
            textBox1.Text = n_client;
            textBox2.Text = f_client;
            textBox3.Text = r_client;
            dateTimePicker1.Value = d_client;

            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"Select ID_benefit From Privileges Where ID_client =" + id_clinet + ";";
            var dr = DB.com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr[0]) == 1) checkBox1.Checked = true;
                    if (Convert.ToInt32(dr[0]) == 2) checkBox2.Checked = true;
                    if (Convert.ToInt32(dr[0]) == 3) checkBox3.Checked = true;
                    if (Convert.ToInt32(dr[0]) == 4) checkBox4.Checked = true;
                }
                dr.Close();
            }
            DB.con.Close();
        }



        private void update_info()
        {
            var d = dateTimePicker1.Value;
            DB.com.Connection = DB.con;
            DB.com.CommandText = @"UPDATE Clients SET "
                                  + "Name = '" + textBox1.Text
                                  + "', Surname = '" + textBox2.Text
                                  + "', Patromic = '" + textBox3.Text
                                  + "', Date_of_birth = '" + d.ToString("dd.MM.yyyy") + "'"
                                  + "Where ID_Client = " + id_clinet +  ";"
                                  + "Delete from Privileges Where ID_client = " + id_clinet + "; ";
            DB.con.Open();
            DB.com.ExecuteNonQuery();
            DB.con.Close();
            if (checkBox1.Checked == true)
            {
                benefits(id_clinet, 1);
            }
            if (checkBox2.Checked == true)
            {
                benefits(id_clinet, 2);
            }
            if (checkBox3.Checked == true)
            {
                benefits(id_clinet, 3);
            }
            if (checkBox4.Checked == true)
            {
                benefits(id_clinet, 4);
            }
            edit = false;
            this.Close();
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_EditForm_Load(object sender, EventArgs e)
        {
            if (edit) Edit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validate_form() && !edit) Add();
            if (validate_form() && edit) update_info();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && checkBox1.Checked == true) checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true) checkBox1.Checked = false;
        }
    }
}
