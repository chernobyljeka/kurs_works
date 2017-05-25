using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.OleDb;


namespace TimeTable_GGAEK_v1._0
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void update()
        {
            this.расписаниеTableAdapter.Fill(this.timetableGGAEKDataSet.Расписание);
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTimeTableGGAEK n = new AboutTimeTableGGAEK();
            n.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "timetableGGAEKDataSet.Расписание". При необходимости она может быть перемещена или удалена.
            this.расписаниеTableAdapter.Fill(this.timetableGGAEKDataSet.Расписание);

        }

        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                update();
                this.Validate();
                this.расписаниеBindingSource.EndEdit();
                this.расписаниеTableAdapter.Update(this.timetableGGAEKDataSet);
                MessageBox.Show("Сохранение завершено");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Сохранение прошло с ошибками! Причина ошибки: " + ex, "Ошибка сохранения");
            }
        }

        private void группуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string grupp = "";
            grupp = Interaction.InputBox("Введите номер группы", "Добавление группы");

            if (grupp != "")
            {
                TimetableGGAEKDataSetTableAdapters.ГруппыTableAdapter группыTableAdapter = new TimetableGGAEKDataSetTableAdapters.ГруппыTableAdapter();
                группыTableAdapter.Insert(grupp);
            }
        }

        private void преподавателяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prepod = "";
            prepod = Interaction.InputBox("Введите ФИО преподавателя", "Добавление преподавателя");
            if (prepod != "")
            {
                TimetableGGAEKDataSetTableAdapters.ПреподавательTableAdapter преподTableAdapter = new TimetableGGAEKDataSetTableAdapters.ПреподавательTableAdapter();
                преподTableAdapter.Insert(prepod);
            }
        }

        private void дисциплинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] d = new int[3];
            PredmetAddcs h = new PredmetAddcs();
            h.Show();
            h.button1.MouseDown += (sender1, e1) =>
            {
                if (h.comboBox1.Text == "" || h.textBox2.Text == "" || h.comboBox2.Text == "" || h.textBox4.Text == "" || h.textBox5.Text == "" || h.textBox6.Text == "") 
                    MessageBox.Show("Необходимо заполнить все поля!");
                else
                {
                    d[0] = Convert.ToInt32(h.textBox4.Text);
                    d[1] = Convert.ToInt32(h.textBox6.Text);
                    d[2] = Convert.ToInt32(h.textBox5.Text);
                    TimetableGGAEKDataSetTableAdapters.ДисциплинаTableAdapter дисциплиныTableAdapter = new TimetableGGAEKDataSetTableAdapters.ДисциплинаTableAdapter();
                    дисциплиныTableAdapter.Insert(h.comboBox1.SelectedItem.ToString(), h.textBox2.Text, h.comboBox2.SelectedItem.ToString(),d[0],d[1],d[2]);
                    h.Close();
                }
            };
            h.button2.MouseDown += (sender1, e1) =>
            {
                h.Close();
            };
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZanyatyeADD h = new ZanyatyeADD();
            h.Show();
            h.button1.MouseDown += (sender1, e1) =>
            {
                try
                {

                    DateTime date = new System.DateTime();
                    date = DateTime.Parse(h.maskedTextBox1.Text);
                    TimetableGGAEKDataSetTableAdapters.РасписаниеTableAdapter расписаниеTableAdapter = new TimetableGGAEKDataSetTableAdapters.РасписаниеTableAdapter();
                    int kol_ch = Convert.ToInt32(h.textBox1.Text);
                    string kab = h.textBox2.Text;
                    расписаниеTableAdapter.Insert(h.comboBox1.SelectedItem.ToString(), h.comboBox2.SelectedItem.ToString(), h.comboBox3.SelectedItem.ToString(), h.comboBox5.SelectedItem.ToString(), h.comboBox4.SelectedItem.ToString(), kol_ch, date, kab);

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\TimetableGGAEK.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.CommandText = "SELECT Вычтено_часов, Останось_часов  FROM Дисциплина WHERE (((Дисциплина.[Группа])='" + h.comboBox1.SelectedItem.ToString()+"') AND ((Дисциплина.[Дисциплина])='" + h.comboBox2.SelectedItem.ToString() + "'))";
                    command.Connection = connection;
                        connection.Open();
                        OleDbDataReader dr = command.ExecuteReader();
                        int v = 0;
                        int o = 0;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                v = Convert.ToInt32(dr["Вычтено_часов"]);
                                o = Convert.ToInt32(dr["Останось_часов"]);
                            }
                            v = v + kol_ch;
                            o = o - kol_ch;
                            connection.Close();
                            connection.Open();
                            command.CommandText = "UPDATE Дисциплина SET Вычтено_часов ='" + v + "',Останось_часов ='"+ o + "'  WHERE (((Дисциплина.[Группа])='" + h.comboBox1.SelectedItem.ToString() + "') AND ((Дисциплина.[Дисциплина])='" + h.comboBox2.SelectedItem.ToString() + "'))";
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка ввода");
                }
                update();
                h.Close();
            };
            h.button2.MouseDown += (sender1, e1) =>
            {
                h.Close();
            };
        }

        private void группуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string grupp = "";
            grupp = Interaction.InputBox("Введите номер группы", "Удаление группы");

            if (grupp != "")
            {
                TimetableGGAEKDataSetTableAdapters.ГруппыTableAdapter группыTableAdapter = new TimetableGGAEKDataSetTableAdapters.ГруппыTableAdapter();
                группыTableAdapter.Delete(grupp);
            }
        }

        private void преподавателяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string prepod = "";
            prepod = Interaction.InputBox("Введите ФИО преподавателя", "Удаление преподавателя");
            if (prepod != "")
            {
                TimetableGGAEKDataSetTableAdapters.ПреподавательTableAdapter преподTableAdapter = new TimetableGGAEKDataSetTableAdapters.ПреподавательTableAdapter();
                преподTableAdapter.Delete(prepod);
            }
        }

        private void дисциплинуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PredmetDel h = new PredmetDel();
            h.Show();
            h.button1.MouseDown += (sender1, e1) =>
            {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\TimetableGGAEK.accdb';OLE DB Services=-1";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "DELETE FROM Дисциплина WHERE Группа ='" + h.comboBox1.SelectedItem.ToString() + "' AND Дисциплина ='" + h.comboBox2.SelectedItem.ToString() + "'";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            h.Close();
            };
            h.button2.MouseDown += (sender1, e1) =>
            {
                h.Close();
            };
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZanytieDel h = new ZanytieDel();
            h.Show();
            h.button1.MouseDown += (sender1, e1) =>
            {
                try
                {
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\TimetableGGAEK.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string s = h.maskedTextBox1.Text;
                    int kol_ch = 0;

                    //Запрос на получение кол-ва часов в удаляемой записи
                    command.CommandText = "SELECT Количество_часов FROM Расписание WHERE Группа ='" + h.comboBox1.SelectedItem.ToString() + "' AND Дисциплина ='" + h.comboBox2.SelectedItem.ToString() + "' AND Дата = #" + s.Replace(".", "/") + "#";
                    connection.Open();
                    OleDbDataReader k = command.ExecuteReader();
                    if (k.HasRows)
                    {
                        while (k.Read())
                        {
                            kol_ch = Convert.ToInt32(k["Количество_часов"]);
                        }  
                    }
                    connection.Close();

                    //Запрос на удаление
                    command.CommandText = "DELETE FROM Расписание WHERE Группа ='" + h.comboBox1.SelectedItem.ToString() + "' AND Дисциплина ='" + h.comboBox2.SelectedItem.ToString() + "' AND Дата = #" + s.Replace(".","/") + "#";
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    //Запросы на получение и вставку данных о дисциплинах
                    command.CommandText = "SELECT Вычтено_часов, Останось_часов  FROM Дисциплина WHERE (((Дисциплина.[Группа])='" + h.comboBox1.SelectedItem.ToString() + "') AND ((Дисциплина.[Дисциплина])='" + h.comboBox2.SelectedItem.ToString() + "'))";
                    connection.Open();
                    OleDbDataReader dr = command.ExecuteReader();
                    int v = 0;
                    int o = 0;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            v = Convert.ToInt32(dr["Вычтено_часов"]);
                            o = Convert.ToInt32(dr["Останось_часов"]);
                        }
                        v = v - kol_ch;
                        o = o + kol_ch;
                        connection.Close();
                        connection.Open();
                        command.CommandText = "UPDATE Дисциплина SET Вычтено_часов ='" + v + "',Останось_часов ='" + o + "'  WHERE (((Дисциплина.[Группа])='" + h.comboBox1.SelectedItem.ToString() + "') AND ((Дисциплина.[Дисциплина])='" + h.comboBox2.SelectedItem.ToString() + "'))";
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    update();
                    h.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка ввода!");
                }
            };
            h.button2.MouseDown += (sender1, e1) =>
            {
                h.Close();
            };
        }

        private void поДисциплинеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report h = new Report();
            h.Show();
            h.button1.MouseDown += (sender1, e1) =>
            {
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\TimetableGGAEK.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT Всего_часов, Вычтено_часов, Останось_часов  FROM Дисциплина WHERE (((Дисциплина.[Группа])='" + h.comboBox1.SelectedItem.ToString() + "') AND ((Дисциплина.[Дисциплина])='" + h.comboBox2.SelectedItem.ToString() + "'))";
                    connection.Open();
                    OleDbDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            h.label3.Text = "Всего часов: " + dr["Всего_часов"].ToString();
                            h.label4.Text = "Вычтено часов: " + dr["Вычтено_часов"].ToString();
                            h.label5.Text = "Осталось часов: " + dr["Останось_часов"].ToString();
                        }
                    }
                    connection.Close();
            };
            h.button2.MouseDown += (sender1, e1) =>
            {
                h.Close();
            };
        }
    }
}
