using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutukin
{
    public partial class add_edit : Form
    {
        public add_edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_edit_Load(object sender, EventArgs e)
        {
            Program.read_bd("SELECT Фамилия FROM Клиент","Фамилия");
            comboBox1.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("SELECT Услуга FROM Услуги", "Услуга");
            comboBox2.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("SELECT [Вид техники] FROM [Вид техники]", "Вид техники");
            comboBox3.DataSource = Program.tmp;
            Program.tmp.Clear();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void add_edit_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client_add n = new Client_add();
            n.Show();
            n.button2.MouseDown += (sender1, e1) =>
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Добавить нового клиента?", "Добавление клиента", buttons);
                
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int maxid;
                        string mybdpath = @"|DataDirectory|\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection connection = new OleDbConnection(conStr);
                        connection.Open();
                        OleDbCommand command = connection.CreateCommand();
                        command.CommandText = "Select MAX(Клиент.КлиентID) from Клиент";
                        maxid = (Int32)command.ExecuteScalar() + 1;
                        string raq = n.dateTimePicker1.Value.ToString().Remove(11).Replace(".", "/");
                        string raq1 = n.dateTimePicker2.Value.ToString().Remove(11).Replace(".", "/");
                        string raq3 = n.dateTimePicker3.Value.ToString().Remove(11).Replace(".", "/");
                        command.CommandText = "Insert INTO  Паспорт (КлиентID, [Серия паспорта], [Номер паспорта], [Индификационный номер], [Кем выдан], [Дата выдачи], [Действительн до]) values (" + maxid + ",'" + n.textBox4.Text + "','" + n.textBox5.Text + "','" + n.textBox6.Text + "','" + n.textBox7.Text + "',#" + raq1 + "#,#" + raq3 + "#);";
                        command.ExecuteNonQuery();
                        command.CommandText = "Insert INTO Клиент (КлиентID, Фамилия, Имя, Отчество, [Год рождения]) values (" + maxid + ",'" + n.textBox1.Text + "','" + n.textBox2.Text + "','" + n.textBox3.Text + "',#" + raq + "#);";
                        command.ExecuteNonQuery();
                        connection.Close();
                        n.Close();
                        add_edit_Load(sender, e);
                       
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ошибка добавления клиента \n"+ ex, "Ошибка добавления");
                    }
                }
            };
        }
    }
}
