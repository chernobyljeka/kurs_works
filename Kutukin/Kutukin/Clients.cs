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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            string mybdpath = @"|DataDirectory|\Кутукин1.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
            OleDbConnection connection = new OleDbConnection(conStr);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT Клиент.*, Паспорт.* FROM Паспорт INNER JOIN Клиент ON Паспорт.КлиентID = Клиент.КлиентID", connection);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = reader["Клиент.КлиентID"];
                dataGridView1.Rows[i].Cells[1].Value = reader["Фамилия"];
                dataGridView1.Rows[i].Cells[2].Value = reader["Имя"];
                dataGridView1.Rows[i].Cells[3].Value = reader["Отчество"];
                dataGridView1.Rows[i].Cells[4].Value = reader["Год рождения"].ToString().Remove(11);
                dataGridView1.Rows[i].Cells[5].Value = reader["Серия паспорта"];
                dataGridView1.Rows[i].Cells[6].Value = reader["Номер паспорта"];
                dataGridView1.Rows[i].Cells[7].Value = reader["Индификационный номер"];
                dataGridView1.Rows[i].Cells[8].Value = reader["Кем выдан"];
                dataGridView1.Rows[i].Cells[9].Value = (reader["Дата выдачи"]).ToString().Remove(11);
                dataGridView1.Rows[i].Cells[10].Value = reader["Действительн до"].ToString().Remove(11);
                i++;
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Удалить запись?", "Удаленеие данных", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        string mybdpath = @"|DataDirectory|\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection con = new OleDbConnection(conStr);
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = con;
                        con.Open();
                        string s = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        command.CommandText = "DELETE Клиент.*, Паспорт.* FROM Паспорт INNER JOIN Клиент ON Паспорт.КлиентID = Клиент.КлиентID WHERE Клиент.КлиентID=Паспорт.КлиентID AND Клиент.КлиентID=" + s + ";";
                        command.ExecuteNonQuery();
                        con.Close();
                        Clients_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("При удалении возникла ошибка!\n" + ex, "Ошибка удаления");
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрана или отсутвует строка для удаления!", "Ошибка удаления");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                                if (dataGridView1.RowCount == 0) { maxid = 1; }
                                else { maxid = (Int32)command.ExecuteScalar() + 1; }
                                
                                string raq = n.dateTimePicker1.Value.ToString().Remove(11).Replace(".", "/");
                                string raq1 = n.dateTimePicker2.Value.ToString().Remove(11).Replace(".", "/");
                                string raq3 = n.dateTimePicker3.Value.ToString().Remove(11).Replace(".", "/");
                                command.CommandText = "Insert INTO  Паспорт (КлиентID, [Серия паспорта], [Номер паспорта], [Индификационный номер], [Кем выдан], [Дата выдачи], [Действительн до]) values (" + maxid + ",'" + n.textBox4.Text + "','" + n.textBox5.Text + "','" + n.textBox6.Text + "','" + n.textBox7.Text + "',#" + raq1 + "#,#" + raq3 + "#);";
                                command.ExecuteNonQuery();
                                command.CommandText = "Insert INTO Клиент (КлиентID, Фамилия, Имя, Отчество, [Год рождения]) values (" + maxid + ",'" + n.textBox1.Text + "','" + n.textBox2.Text + "','" + n.textBox3.Text + "',#" + raq + "#);";
                                command.ExecuteNonQuery();
                                connection.Close();
                                n.Close();
                                Clients_Load(sender, e);
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка добавления клиента", "Ошибка добавления");
                            }
                        }
                    };
            
        }
    }
}
