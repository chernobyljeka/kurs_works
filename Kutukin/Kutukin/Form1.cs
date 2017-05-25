using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutukin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
            OleDbConnection connection = new OleDbConnection(conStr);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT [Оказание услуг].*, Неисправность.*, Оплата.*, Клиент.*, Услуги.*, [Вид техники].* FROM Услуги INNER JOIN (Клиент INNER JOIN ([Вид техники] INNER JOIN (Оплата INNER JOIN ([Оказание услуг] INNER JOIN Неисправность ON [Оказание услуг].[Код оказаной услуги] = Неисправность.[Код оказаной услуги]) ON Оплата.[Код оказанной услуги] = [Оказание услуг].[Код оказаной услуги]) ON [Вид техники].[Код вида] = [Оказание услуг].[Вид техники]) ON Клиент.КлиентID = [Оказание услуг].КлиентID) ON Услуги.УслугаID = [Оказание услуг].[Код услуги]", connection);
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = reader["Оказание услуг.Код оказаной услуги"];
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(reader["Фамилия"] +" "+reader["Имя"]);
                dataGridView1.Rows[i].Cells[2].Value = reader["Услуга"]; 
                dataGridView1.Rows[i].Cells[3].Value = reader["Вид техники.Вид техники"];
                dataGridView1.Rows[i].Cells[4].Value = reader["Модель"];
                dataGridView1.Rows[i].Cells[5].Value = reader["Номер техники"];
                dataGridView1.Rows[i].Cells[6].Value = reader["На гарантии"];
                dataGridView1.Rows[i].Cells[7].Value = reader["Заявленная неисправность"];
                dataGridView1.Rows[i].Cells[8].Value = reader["Выявленная неисправность"];
                dataGridView1.Rows[i].Cells[9].Value = reader["Гарантийный случай"];
                dataGridView1.Rows[i].Cells[10].Value = reader["Сумма к оплате"];
                i++;
            }
            connection.Close();
           
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 n = new AboutBox1();
            n.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add_edit n = new add_edit();
            n.Show();
            this.Hide();
            n.button2.MouseDown += (sender1, e1) =>
            {
                 MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Сохранить изменения?", "Сохранение данных", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int maxid;
                        int clientid;
                        int usluga;
                        int tech;
                        string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection connection = new OleDbConnection(conStr);
                        connection.Open();
                        OleDbCommand command = connection.CreateCommand();
                        command.CommandText = "Select MAX([Код оказаной услуги]) from [Оказание услуг];";
                        if (dataGridView1.RowCount==0) { maxid = 1; }
                        else { maxid = (Int32)command.ExecuteScalar() + 1; }

                        

                        command.CommandText = "Select КлиентID from Клиент where Фамилия='" + n.comboBox1.SelectedItem.ToString() + "';";
                        clientid = (Int32)command.ExecuteScalar();
                        command.CommandText = "Select УслугаID from Услуги where Услуга='" + n.comboBox2.SelectedItem.ToString() + "';";
                        usluga = (Int32)command.ExecuteScalar();
                        command.CommandText = "Select [Код вида] from [Вид техники] where [Вид техники]='" + n.comboBox3.SelectedItem.ToString() + "';";
                        tech = (Int32)command.ExecuteScalar();


                        command.CommandText = "Insert into Оплата ([Код оказанной услуги],[Сумма к оплате]) values (" + maxid + "," + n.textBox5.Text + ")";
                        command.ExecuteNonQuery();
                        
                        command.CommandText = "Insert into [Оказание услуг] ([Код оказаной услуги], КлиентID, [Код услуги], [Вид техники], Модель, [Номер техники], [На гарантии]) values (" + maxid + "," + clientid + "," + usluga + "," + tech + ",'" + n.textBox1.Text + "','" + n.textBox2.Text + "'," + n.checkBox1.Checked.ToString() + ")";
                        command.ExecuteNonQuery();
                       
                        command.CommandText = "Insert into Неисправность ([Код оказаной услуги],[Заявленная неисправность],[Выявленная неисправность], [Гарантийный случай]) values (" + maxid + ",'" + n.textBox3.Text + "','" + n.textBox4.Text + "'," + n.checkBox2.Checked.ToString() + ")";
                        command.ExecuteNonQuery();
                        connection.Close();
                        n.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка вставки данных!\n\n" + ex, "Ошибка добавления");
                    }
                    finally
                    {
                        Thread.Sleep(500);
                        Form1_Load(sender, e);
                        this.Show();
                    }
                }
            };
            n.button1.MouseDown += (sender2, e2) =>
                {
                    this.Show();
                };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                edit r = new edit();
                r.Show();
                this.Hide();
                string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
                string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                OleDbConnection connection = new OleDbConnection(conStr);
                connection.Open();
                string s = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                OleDbCommand command = new OleDbCommand("SELECT [Оказание услуг].*, Неисправность.*, Оплата.*, Клиент.*, Услуги.*, [Вид техники].* FROM Услуги INNER JOIN (Клиент INNER JOIN ([Вид техники] INNER JOIN (Оплата INNER JOIN ([Оказание услуг] INNER JOIN Неисправность ON [Оказание услуг].[Код оказаной услуги] = Неисправность.[Код оказаной услуги]) ON Оплата.[Код оказанной услуги] = [Оказание услуг].[Код оказаной услуги]) ON [Вид техники].[Код вида] = [Оказание услуг].[Вид техники]) ON Клиент.КлиентID = [Оказание услуг].КлиентID) ON Услуги.УслугаID = [Оказание услуг].[Код услуги] WHERE  [Оказание услуг].[Код оказаной услуги]=Неисправность.[Код оказаной услуги] AND Неисправность.[Код оказаной услуги]=[Код оказанной услуги] AND [Код оказанной услуги]=" + s + ";", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    r.comboBox1.SelectedIndex = -1;
                    r.comboBox2.SelectedIndex = -1;
                    r.comboBox3.SelectedIndex = -1;
                    r.comboBox1.SelectedText = reader["Фамилия"].ToString();
                    r.comboBox2.SelectedText = reader["Услуга"].ToString();
                    r.comboBox3.SelectedText = reader["Вид техники.Вид техники"].ToString();
                    r.textBox1.Text = reader["Модель"].ToString();
                    r.textBox2.Text = reader["Номер техники"].ToString();
                    r.textBox3.Text = reader["Заявленная неисправность"].ToString();
                    r.textBox4.Text = reader["Выявленная неисправность"].ToString();
                    r.textBox5.Text = reader["Сумма к оплате"].ToString();
                    r.checkBox1.Checked = Convert.ToBoolean(reader["На гарантии"]);
                    r.checkBox2.Checked = Convert.ToBoolean(reader["Гарантийный случай"]);
                }
                connection.Close();
                r.button2.MouseDown += (sender1, e1) =>
                    {
                        int clientid;
                        int usluga;
                        int tech;
                      
                        string my = Application.StartupPath + @"\Кутукин1.accdb";
                        string conSt = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + my;
                        OleDbConnection conn = new OleDbConnection(conSt);
                        OleDbCommand com = conn.CreateCommand();
                        conn.Open();
                        com.CommandText = "Select КлиентID from Клиент where Фамилия='" + r.comboBox1.Text.ToString() + "'";
                        clientid = (Int32)com.ExecuteScalar();
                        com.CommandText = "Select УслугаID from Услуги where Услуга='" + r.comboBox2.Text.ToString() + "'";
                        usluga = (Int32)com.ExecuteScalar();
                        com.CommandText = "Select [Код вида] from [Вид техники] where [Вид техники]='" + r.comboBox3.Text.ToString() + "'";
                        tech = (Int32)com.ExecuteScalar();
                        com.CommandText = @"UPDATE  [Оказание услуг], Неисправность, Оплата " +
                            "SET КлиентID=@clid, [Код услуги]=@usluga,[Вид техники]=@tech, Модель=@mod, [Номер техники]=@nt, [На гарантии]=@ng, [Заявленная неисправность]=@zn, [Выявленная неисправность]=@vn, [Гарантийный случай]=@gn," +
                             "[Сумма к оплате]=@sum WHERE [Код оказанной услуги]=@Id";
                        com.Parameters.AddWithValue("@Id",s);
                        com.Parameters.AddWithValue("@clid", clientid);
                        com.Parameters.AddWithValue("@idusl", usluga);
                        com.Parameters.AddWithValue("@vt", tech);
                        com.Parameters.AddWithValue("@mod", r.textBox1.Text);
                        com.Parameters.AddWithValue("@nt", r.textBox2.Text);
                        com.Parameters.AddWithValue("@ng", r.checkBox1.Checked);
                        com.Parameters.AddWithValue("@zn", r.textBox3.Text);
                        com.Parameters.AddWithValue("@vn", r.textBox4.Text);
                        com.Parameters.AddWithValue("@gn", r.checkBox2.Checked);
                        com.Parameters.AddWithValue("@sum", r.textBox5.Text);

                        com.ExecuteNonQuery();
                        conn.Close();
                        r.Close();
                        this.Show();
                    };
                r.button1.MouseDown += (sender1, e1) =>
                    {
                        this.Show();
                    };
            }
            else
            {
                MessageBox.Show("Не выбрана строка для изменения","Ошибка изменения данных");
            }
           
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
                        string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection con = new OleDbConnection(conStr);
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = con;
                        con.Open();
                        string s = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        command.CommandText = "DELETE Неисправность.*, Оплата.*, [Оказание услуг].* FROM Оплата INNER JOIN ([Оказание услуг] INNER JOIN Неисправность ON [Оказание услуг].[Код оказаной услуги] = Неисправность.[Код оказаной услуги]) ON Оплата.[Код оказанной услуги] = [Оказание услуг].[Код оказаной услуги] WHERE [Оказание услуг].[Код оказаной услуги]=" + s + ";";
                        command.ExecuteNonQuery();
                        con.Close();
                        Form1_Load(sender, e);
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

        private void сохранитьИзмененияВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Form1_Load(sender, e);
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients n = new Clients();
            n.Show();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uslugi_add n = new uslugi_add();
            n.Show();
            this.Hide();
            n.button2.MouseDown += (sender1, e1) =>
            {
                 MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Добавить новый вид услуг?", "Добавление услуг", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection connection = new OleDbConnection(conStr);
                        connection.Open();
                        OleDbCommand command = connection.CreateCommand();
                        command.CommandText = "Select MAX([УслугаID]) from Услуги";
                        int maxid = (Int32)command.ExecuteScalar() + 1;
                        command.CommandText = "Insert into Услуги (УслугаID,Услуга) values (" + maxid + ",'" + n.textBox1.Text.ToString() + "')";
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка добавления услуги", "Ошибка добавления");
                    }
                    finally
                    {
                        n.Close();
                        this.Show();
                    }

                   

                }
            };
            n.button1.MouseDown += (sender1, e1) =>
                {
                    this.Close();
                };
        }

        private void видыТехникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tech_add n = new tech_add();
            n.Show();
            this.Hide();
            n.button2.MouseDown += (sender1, e1) =>
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Добавить новый вид техники?", "Добавление вида техники", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int maxid;
                        string mybdpath = Application.StartupPath + @"\Кутукин1.accdb";
                        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
                        OleDbConnection connection = new OleDbConnection(conStr);
                        connection.Open();
                        OleDbCommand command = connection.CreateCommand();
                        command.CommandText = "Select MAX([Код вида]) from [Вид техники]";
                        maxid = (Int32)command.ExecuteScalar() + 1;
                        command.CommandText = "Insert into [Вид техники] ([Код вида],[Вид техники]) values (" + maxid + ",'" + n.textBox1.Text.ToString() + "')";
                        command.ExecuteNonQuery();
                        connection.Close();
                        n.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка добавления вида техники", "Ошибка добавления");
                    }
                    finally
                    {
                        n.Close();
                        this.Show();
                    }



                }
            };
            n.button1.MouseDown += (sender1, e1) =>
            {
                this.Show();
            };
        }

        private void выходAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report n = new Report();
            n.ShowDialog();
        }
    }
}
