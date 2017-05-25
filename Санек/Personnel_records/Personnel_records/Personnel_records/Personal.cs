using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Personnel_records
{
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void Update_personal()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBase_sotrudnikiDataSet1.Увольнение". При необходимости она может быть перемещена или удалена.
            this.увольнениеTableAdapter1.Fill(this.dataBase_sotrudnikiDataSet1.Увольнение);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBase_sotrudnikiDataSet1.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter1.Fill(this.dataBase_sotrudnikiDataSet1.Сотрудники);
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBase_sotrudnikiDataSet1.Увольнение". При необходимости она может быть перемещена или удалена.
            this.увольнениеTableAdapter1.Fill(this.dataBase_sotrudnikiDataSet1.Увольнение);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBase_sotrudnikiDataSet1.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter1.Fill(this.dataBase_sotrudnikiDataSet1.Сотрудники);
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            Persona n = new Persona();
            n.textBox1.ReadOnly = true;
            n.textBox5.ReadOnly = true;
            n.textBox7.ReadOnly = true;
            n.textBox8.ReadOnly = true;
            n.textBox9.ReadOnly = true;
            n.Text = "Личное дело: " + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString() + " " + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString(); ;
            n.Show();
            n.textBox1.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            n.textBox5.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            n.textBox7.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            n.textBox8.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            n.textBox9.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            n.textBox2.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString();
            n.textBox3.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString();
            n.textBox4.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[3].Value.ToString();
            n.maskedTextBox1.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[4].Value.ToString();
            n.textBox6.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[5].Value.ToString();
            n.textBox32.Text = сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[6].Value.ToString();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Должность.[Основная должность], Должность.[Дополнительная должность], Должность.[Дополнительная должность на предприятиии], Должность.[Место работы по совместительству], Паспорт.[Серия], Паспорт.[Номер], Паспорт.[Личный номер паспорта], Паспорт.[Кем выдан], Паспорт.[Гражданство], Паспорт.[Дата выдачи], Паспорт.[Срок действия], Прописка.[Область], Прописка.[Район], Прописка.[Населенный_пункт], Прописка.[Улица], Прописка.[Дом], Прописка.[Корпус], Прописка.[Квартира],Место_жительста.[Область], Место_жительста.[Район], Место_жительста.[Населенный_пункт], Место_жительста.[Улица], Место_жительста.[Дом], Место_жительста.[Корпус], Место_жительста.[Квартира]  FROM Сотрудники, Должность, Паспорт, Прописка, Место_жительста WHERE Сотрудники.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Сотрудники.Табельный_номер=" + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
            
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        n.textBox12.Text = dr["Основная должность"].ToString();
                        n.textBox10.Text = dr["Дополнительная должность"].ToString();
                        n.checkBox1.Checked = Convert.ToBoolean(dr["Дополнительная должность на предприятиии"]);
                        n.textBox11.Text = dr["Место работы по совместительству"].ToString();
                        n.textBox13.Text = dr["Серия"].ToString();
                        n.textBox14.Text = dr["Номер"].ToString();
                        n.textBox15.Text = dr["Личный номер паспорта"].ToString();
                        n.textBox16.Text = dr["Кем выдан"].ToString();
                        n.textBox17.Text = dr["Гражданство"].ToString();
                        n.maskedTextBox2.Text = dr["Дата выдачи"].ToString();
                        n.maskedTextBox3.Text = dr["Срок действия"].ToString();
                        n.textBox18.Text = dr["Прописка.Область"].ToString();
                        n.textBox19.Text = dr["Прописка.Район"].ToString();
                        n.textBox20.Text = dr["Прописка.Населенный_пункт"].ToString();
                        n.textBox21.Text = dr["Прописка.Улица"].ToString();
                        n.textBox22.Text = dr["Прописка.Дом"].ToString();
                        n.textBox23.Text = dr["Прописка.Корпус"].ToString();
                        n.textBox24.Text = dr["Прописка.Квартира"].ToString();
                        n.textBox25.Text = dr["Место_жительста.Область"].ToString();
                        n.textBox26.Text = dr["Место_жительста.Район"].ToString();
                        n.textBox27.Text = dr["Место_жительста.Населенный_пункт"].ToString();
                        n.textBox28.Text = dr["Место_жительста.Улица"].ToString();
                        n.textBox29.Text = dr["Место_жительста.Дом"].ToString();
                        n.textBox30.Text = dr["Место_жительста.Корпус"].ToString();
                        n.textBox31.Text = dr["Место_жительста.Квартира"].ToString();
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }

            n.button1.MouseDown += (sender1, e1) =>
            {
                Update_personal();
                n.Close();
            };
        
            n.button2.MouseDown += (sender1, e1) =>
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Сохранить изменения?", "Сохранение данных", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                try
                {
                        string s = n.maskedTextBox1.Text;
                        string s1 = n.maskedTextBox2.Text;
                        string s2 = n.maskedTextBox3.Text;
                        connection.Open();
                        command.CommandText = "UPDATE Сотрудники, Должность, Паспорт, Прописка, Место_жительста SET Сотрудники.Фамилия ='" + n.textBox2.Text + "', Сотрудники.Имя='" + n.textBox3.Text + "', Сотрудники.[Отчество]='" + n.textBox4.Text + "', Сотрудники.[Дата_рождения]=#" + s.Replace(".", "/") + "#, Сотрудники.[Возраст]='" + n.textBox6.Text + "', Сотрудники.[Приказ о зачислении]='" + n.textBox32.Text + "', Должность.[Основная должность]='" + n.textBox12.Text + "', Должность.[Дополнительная должность]='" + n.textBox10.Text + "', Должность.[Дополнительная должность на предприятиии]='" + Convert.ToInt32(n.checkBox1.Checked) + "', Должность.[Место работы по совместительству]='" + n.textBox11.Text + "', Паспорт.[Серия]='" + n.textBox13.Text + "', Паспорт.[Номер]='" + n.textBox14.Text + "', Паспорт.[Личный номер паспорта]='" + n.textBox15.Text + "', Паспорт.[Кем выдан]='" + n.textBox16.Text + "', Паспорт.[Гражданство]='" + n.textBox17.Text + "', Паспорт.[Дата выдачи]=#" + s1.Replace(".", "/") + "#, Паспорт.[Срок действия]=#" + s2.Replace(".", "/") + "#, Прописка.[Область]='" + n.textBox18.Text + "', Прописка.[Район]='" + n.textBox19.Text + "', Прописка.[Населенный_пункт]='" + n.textBox20.Text + "', Прописка.[Улица]='" + n.textBox21.Text + "', Прописка.[Дом]='" + n.textBox22.Text + "', Прописка.[Корпус]='" + n.textBox23.Text + "', Прописка.[Квартира]='" + n.textBox24.Text + "', Место_жительста.[Область]='" + n.textBox25.Text + "', Место_жительста.[Район]='" + n.textBox26.Text + "', Место_жительста.[Населенный_пункт]='" + n.textBox27.Text + "', Место_жительста.[Улица]='" + n.textBox28.Text + "', Место_жительста.[Дом]='" + n.textBox29.Text + "', Место_жительста.[Корпус]='" + n.textBox30.Text + "', Место_жительста.[Квартира]='" + n.textBox31.Text + "' WHERE Сотрудники.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Сотрудники.Табельный_номер=" + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                        command.ExecuteNonQuery();
                        connection.Close();
                        System.Threading.Thread.Sleep(500);
                        Update_personal();
                    }

                    catch
                    {
                        MessageBox.Show("Не верно ввведены даныые! Проверте правильность ввода!", "Ошибка ввода!");
                    }
                }   
            };
            
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Persona n = new Persona();
            n.Show();
            n.button2.Text = "Добавить";
            n.label7.Visible = false;
            n.textBox5.Visible = false;
            n.label8.Visible = false;
            n.label9.Visible = false;
            n.label10.Visible = false;
            n.textBox7.Visible = false;
            n.textBox8.Visible = false;
            n.textBox9.Visible = false;
            n.Text = "Добавление сотрудника";
            DateTime d = new System.DateTime();
            DateTime dv = new System.DateTime();
            DateTime ds = new System.DateTime();
            n.button2.MouseDown += (sender1, e1) =>
                {
                    try
                    {
                        d = DateTime.Parse(n.maskedTextBox1.Text);
                    DataBase_sotrudnikiDataSetTableAdapters.СотрудникиTableAdapter sta = new DataBase_sotrudnikiDataSetTableAdapters.СотрудникиTableAdapter();
                    sta.Insert(Convert.ToInt32(n.textBox1.Text), n.textBox2.Text, n.textBox3.Text, n.textBox4.Text, d, Convert.ToInt32(n.textBox6.Text), n.textBox32.Text);

                        DataBase_sotrudnikiDataSetTableAdapters.ДолжностьTableAdapter dta = new DataBase_sotrudnikiDataSetTableAdapters.ДолжностьTableAdapter();
                        dta.Insert(Convert.ToInt32(n.textBox1.Text), n.textBox12.Text, n.textBox10.Text, Convert.ToBoolean(n.checkBox1.Checked), n.textBox11.Text);

                        DataBase_sotrudnikiDataSetTableAdapters.ПаспортTableAdapter pasaport = new DataBase_sotrudnikiDataSetTableAdapters.ПаспортTableAdapter();
                            dv = DateTime.Parse(n.maskedTextBox2.Text);
                            ds = DateTime.Parse(n.maskedTextBox3.Text);
                        pasaport.Insert(Convert.ToInt32(n.textBox1.Text), n.textBox13.Text, Convert.ToInt32(n.textBox14.Text), n.textBox15.Text, n.textBox16.Text, n.textBox17.Text, dv, ds);

                        DataBase_sotrudnikiDataSetTableAdapters.ПропискаTableAdapter propiska = new DataBase_sotrudnikiDataSetTableAdapters.ПропискаTableAdapter();
                        propiska.Insert(Convert.ToInt32(n.textBox1.Text), n.textBox18.Text, n.textBox19.Text, n.textBox20.Text, n.textBox21.Text, n.textBox22.Text, n.textBox23.Text, n.textBox24.Text);

                        DataBase_sotrudnikiDataSetTableAdapters.Место_жительстаTableAdapter mjta = new DataBase_sotrudnikiDataSetTableAdapters.Место_жительстаTableAdapter();
                        mjta.Insert(Convert.ToInt32(n.textBox1.Text), n.textBox25.Text, n.textBox26.Text, n.textBox27.Text, n.textBox28.Text, n.textBox29.Text, n.textBox30.Text, n.textBox31.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка ввода. Проверте правильность введенных данных.", "Ошибка ввода");
                    }
                    finally
                    {
                        Update_personal();
                        n.Close();
                    }
                    
                };

            n.button1.MouseDown += (sender1, e1) =>
            {
                n.Close();
                Update_personal();
            };
        }

        private void добавитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void действующиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void открытьЛичноеДелоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_personal();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Uvol_dialog r = new Uvol_dialog();
            r.Show();
            r.button2.MouseDown += (sender1, e1) =>
           {
               string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
               OleDbConnection connection = new OleDbConnection(connectionString);
               OleDbCommand command = new OleDbCommand();
               command.CommandText = "SELECT * FROM Сотрудники WHERE Сотрудники.[Табельный_номер]=" + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
               command.Connection = connection;
               try
               {
                   connection.Open();
                   OleDbDataReader dr = command.ExecuteReader();
                   string[] x = new string[7];
                   if (dr.HasRows)
                   {
                       while (dr.Read())
                       {
                           x[0] = dr["Табельный_номер"].ToString();
                           x[1] = dr["Фамилия"].ToString();
                           x[2] = dr["Имя"].ToString();
                           x[3] = dr["Отчество"].ToString();
                           x[4] = dr["Дата_рождения"].ToString();
                           x[5] = dr["Возраст"].ToString();
                       }

                   }
                   connection.Close();
                   command.CommandText = "DELETE FROM Сотрудники WHERE Сотрудники.[Табельный_номер]=" + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                   connection.Open();
                   command.ExecuteNonQuery();
                   connection.Close();
                   DataBase_sotrudnikiDataSetTableAdapters.УвольнениеTableAdapter uta = new DataBase_sotrudnikiDataSetTableAdapters.УвольнениеTableAdapter();
                   DateTime data_r = new System.DateTime();
                   DateTime data_t = new System.DateTime();
                   data_r = DateTime.Parse(x[4]);
                   data_t = DateTime.Parse(r.maskedTextBox1.Text);
                   uta.Insert(Convert.ToInt32(x[0]), x[1], x[2], x[3], data_r, Convert.ToInt32(x[5]), data_t, r.textBox1.Text);
                   System.Threading.Thread.Sleep(500);
                   Update_personal();
                   
               }
               catch (Exception ex)
               {
                   Update_personal();
                   MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
               }

               finally
               {
                   Update_personal();
                   r.Close();
               }
           };
            r.button1.MouseDown += (sender1, e1) =>
            {
                r.Close();
            };
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
                Persona n = new Persona();
                n.textBox1.ReadOnly = true;
                n.textBox5.ReadOnly = true;
                n.textBox7.ReadOnly = true;
                n.textBox8.ReadOnly = true;
                n.textBox9.ReadOnly = true;
                n.label35.Visible = true;
                n.maskedTextBox4.Visible = true;
                n.Text = "Личное дело: " + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString() + " " + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString(); ;
                n.Show();
                n.textBox1.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                n.textBox5.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                n.textBox7.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                n.textBox8.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                n.textBox9.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                n.textBox2.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString();
                n.textBox3.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString();
                n.textBox4.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[3].Value.ToString();
                n.maskedTextBox1.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[4].Value.ToString();
                n.textBox6.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[5].Value.ToString();
                n.maskedTextBox4.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[6].Value.ToString();
                n.textBox32.Text = увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[7].Value.ToString();

                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Должность.[Основная должность], Должность.[Дополнительная должность], Должность.[Дополнительная должность на предприятиии], Должность.[Место работы по совместительству], Паспорт.[Серия], Паспорт.[Номер], Паспорт.[Личный номер паспорта], Паспорт.[Кем выдан], Паспорт.[Гражданство], Паспорт.[Дата выдачи], Паспорт.[Срок действия], Прописка.[Область], Прописка.[Район], Прописка.[Населенный_пункт], Прописка.[Улица], Прописка.[Дом], Прописка.[Корпус], Прописка.[Квартира],Место_жительста.[Область], Место_жительста.[Район], Место_жительста.[Населенный_пункт], Место_жительста.[Улица], Место_жительста.[Дом], Место_жительста.[Корпус], Место_жительста.[Квартира]  FROM Увольнение, Должность, Паспорт, Прописка, Место_жительста WHERE Увольнение.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Увольнение.Табельный_номер=" + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                try
                {
                    connection.Open();
                    OleDbDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            n.textBox12.Text = dr["Основная должность"].ToString();
                            n.textBox10.Text = dr["Дополнительная должность"].ToString();
                            n.checkBox1.Checked = Convert.ToBoolean(dr["Дополнительная должность на предприятиии"]);
                            n.textBox11.Text = dr["Место работы по совместительству"].ToString();
                            n.textBox13.Text = dr["Серия"].ToString();
                            n.textBox14.Text = dr["Номер"].ToString();
                            n.textBox15.Text = dr["Личный номер паспорта"].ToString();
                            n.textBox16.Text = dr["Кем выдан"].ToString();
                            n.textBox17.Text = dr["Гражданство"].ToString();
                            n.maskedTextBox2.Text = dr["Дата выдачи"].ToString();
                            n.maskedTextBox3.Text = dr["Срок действия"].ToString();
                            n.textBox18.Text = dr["Прописка.Область"].ToString();
                            n.textBox19.Text = dr["Прописка.Район"].ToString();
                            n.textBox20.Text = dr["Прописка.Населенный_пункт"].ToString();
                            n.textBox21.Text = dr["Прописка.Улица"].ToString();
                            n.textBox22.Text = dr["Прописка.Дом"].ToString();
                            n.textBox23.Text = dr["Прописка.Корпус"].ToString();
                            n.textBox24.Text = dr["Прописка.Квартира"].ToString();
                            n.textBox25.Text = dr["Место_жительста.Область"].ToString();
                            n.textBox26.Text = dr["Место_жительста.Район"].ToString();
                            n.textBox27.Text = dr["Место_жительста.Населенный_пункт"].ToString();
                            n.textBox28.Text = dr["Место_жительста.Улица"].ToString();
                            n.textBox29.Text = dr["Место_жительста.Дом"].ToString();
                            n.textBox30.Text = dr["Место_жительста.Корпус"].ToString();
                            n.textBox31.Text = dr["Место_жительста.Квартира"].ToString();
                        }

                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
                }

                n.button1.MouseDown += (sender1, e1) =>
                {
                    Update_personal();
                    n.Close();
                };

                n.button2.MouseDown += (sender1, e1) =>
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show("Сохранить изменения?", "Сохранение данных", buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            string s = n.maskedTextBox1.Text;
                            string s1 = n.maskedTextBox2.Text;
                            string s2 = n.maskedTextBox3.Text;
                            string s3 = n.maskedTextBox4.Text;
                            connection.Open();
                            command.CommandText = "UPDATE Увольнение, Должность, Паспорт, Прописка, Место_жительста SET Увольнение.Фамилия ='" + n.textBox2.Text + "', Увольнение.Имя='" + n.textBox3.Text + "', Увольнение.[Отчество]='" + n.textBox4.Text + "', Увольнение.[Дата_рождения]=#" + s.Replace(".", "/") + "#, Увольнение.[Возраст]='" + n.textBox6.Text + "', Увольнение.[Дата увольнения]=#" + s3.Replace(".", "/") + "#, Увольнение.[Приказ об увольнении]='" + n.textBox32.Text + "', Должность.[Основная должность]='" + n.textBox12.Text + "', Должность.[Дополнительная должность]='" + n.textBox10.Text + "', Должность.[Дополнительная должность на предприятиии]='" + Convert.ToInt32(n.checkBox1.Checked) + "', Должность.[Место работы по совместительству]='" + n.textBox11.Text + "', Паспорт.[Серия]='" + n.textBox13.Text + "', Паспорт.[Номер]='" + n.textBox14.Text + "', Паспорт.[Личный номер паспорта]='" + n.textBox15.Text + "', Паспорт.[Кем выдан]='" + n.textBox16.Text + "', Паспорт.[Гражданство]='" + n.textBox17.Text + "', Паспорт.[Дата выдачи]=#" + s1.Replace(".", "/") + "#, Паспорт.[Срок действия]=#" + s2.Replace(".", "/") + "#, Прописка.[Область]='" + n.textBox18.Text + "', Прописка.[Район]='" + n.textBox19.Text + "', Прописка.[Населенный_пункт]='" + n.textBox20.Text + "', Прописка.[Улица]='" + n.textBox21.Text + "', Прописка.[Дом]='" + n.textBox22.Text + "', Прописка.[Корпус]='" + n.textBox23.Text + "', Прописка.[Квартира]='" + n.textBox24.Text + "', Место_жительста.[Область]='" + n.textBox25.Text + "', Место_жительста.[Район]='" + n.textBox26.Text + "', Место_жительста.[Населенный_пункт]='" + n.textBox27.Text + "', Место_жительста.[Улица]='" + n.textBox28.Text + "', Место_жительста.[Дом]='" + n.textBox29.Text + "', Место_жительста.[Корпус]='" + n.textBox30.Text + "', Место_жительста.[Квартира]='" + n.textBox31.Text + "' WHERE Увольнение.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Увольнение.Табельный_номер=" + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                            command.ExecuteNonQuery();
                            connection.Close();
                            System.Threading.Thread.Sleep(500);
                            Update_personal();
                        }

                        catch
                        {
                            MessageBox.Show("Не верно ввведены даныые! Проверте правильность ввода!", "Ошибка ввода!");
                        }


                    }
                };
            
            
        }

        private void уволитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            Uvol_dialog vost = new Uvol_dialog();
            vost.Text = "Востоновление сотрудника";
            vost.label1.Text = "Востоновить выбраного сотрудника?";
            vost.label2.Visible = false;
            vost.label2.Location = new Point(13,55);
            vost.maskedTextBox1.Visible= false;
            vost.button2.Text = "Востоновить";
            vost.Show();
            vost.button2.MouseDown += (sender1, e1) =>
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "SELECT * FROM Увольнение WHERE Увольнение.[Табельный_номер]=" + this.увольнениеDataGridView.Rows[this.увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                command.Connection = connection;
                try
                {
                    connection.Open();
                    OleDbDataReader dr = command.ExecuteReader();
                    string[] x = new string[6];
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            x[0] = dr["Табельный_номер"].ToString();
                            x[1] = dr["Фамилия"].ToString();
                            x[2] = dr["Имя"].ToString();
                            x[3] = dr["Отчество"].ToString();
                            x[4] = dr["Дата_рождения"].ToString();
                            x[5] = dr["Возраст"].ToString();
                        }

                    }
                    connection.Close();
                    command.CommandText = "DELETE FROM Увольнение WHERE Увольнение.[Табельный_номер]=" + this.увольнениеDataGridView.Rows[this.увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    DataBase_sotrudnikiDataSetTableAdapters.СотрудникиTableAdapter sta = new DataBase_sotrudnikiDataSetTableAdapters.СотрудникиTableAdapter();
                    DateTime data_r = new System.DateTime();
                    data_r = DateTime.Parse(x[4]);
                    sta.Insert(Convert.ToInt32(x[0]), x[1], x[2], x[3], data_r, Convert.ToInt32(x[5]), vost.textBox1.Text.ToString());
                    System.Threading.Thread.Sleep(500);
                    Update_personal();
                    vost.Close();
                }

                catch (Exception ex)
                {
                    Update_personal();
                    MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
                }

            };
              
                vost.button1.MouseDown += (sender1, e1) =>
                {
                    Update_personal();
                    vost.Close();
                };
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveD = new SaveFileDialog();
            saveD.Filter = "Файл MS Word 2007-2013 (*.docx)|*.docx";
            if (saveD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    var wordDoc = wordApp.Documents.Open(AppDomain.CurrentDomain.BaseDirectory + @".\Report\example.docx");
                    
            
            export_d("{status}", "действующего", wordDoc);
            export_d("{vpr}", "Приказ о зачислении:", wordDoc);
            export_d("{pr}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[6].Value.ToString(), wordDoc);
            export_d("{tab_n}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString(), wordDoc);
            export_d("{fam}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString(), wordDoc);
            export_d("{name}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString(), wordDoc);
            export_d("{otch}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[3].Value.ToString(), wordDoc);
            export_d("{dr}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[4].Value.ToString().Remove(10), wordDoc);
            export_d("{voz}", сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[5].Value.ToString(), wordDoc);

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Должность.[Основная должность], Должность.[Дополнительная должность], Должность.[Дополнительная должность на предприятиии], Должность.[Место работы по совместительству], Паспорт.[Серия], Паспорт.[Номер], Паспорт.[Личный номер паспорта], Паспорт.[Кем выдан], Паспорт.[Гражданство], Паспорт.[Дата выдачи], Паспорт.[Срок действия], Прописка.[Область], Прописка.[Район], Прописка.[Населенный_пункт], Прописка.[Улица], Прописка.[Дом], Прописка.[Корпус], Прописка.[Квартира],Место_жительста.[Область], Место_жительста.[Район], Место_жительста.[Населенный_пункт], Место_жительста.[Улица], Место_жительста.[Дом], Место_жительста.[Корпус], Место_жительста.[Квартира]  FROM Сотрудники, Должность, Паспорт, Прописка, Место_жительста WHERE Сотрудники.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Сотрудники.Табельный_номер=" + сотрудникиDataGridView.Rows[сотрудникиDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";

            try
            {

                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        export_d("{dol}", dr["Основная должность"].ToString(), wordDoc);
                        export_d("{ddol}", dr["Дополнительная должность"].ToString(), wordDoc);
                        export_d("{mdr}", dr["Место работы по совместительству"].ToString(), wordDoc);

                        export_d("{ser}", dr["Серия"].ToString(), wordDoc);
                        export_d("{nom}", dr["Номер"].ToString(), wordDoc);
                        export_d("{lich}", dr["Личный номер паспорта"].ToString(), wordDoc);
                        export_d("{kem_v}", dr["Кем выдан"].ToString(), wordDoc);
                        export_d("{gr}", dr["Гражданство"].ToString(), wordDoc);
                        export_d("{kog}", dr["Дата выдачи"].ToString().Remove(10), wordDoc);
                        export_d("{srok}", dr["Срок действия"].ToString().Remove(10), wordDoc);

                        export_d("{obl}", dr["Прописка.Область"].ToString(), wordDoc);
                        export_d("{ra}", dr["Прописка.Район"].ToString(), wordDoc);
                        export_d("{np}", dr["Прописка.Населенный_пункт"].ToString(), wordDoc);
                        export_d("{ul}", dr["Прописка.Улица"].ToString(), wordDoc);
                        export_d("{dom}", dr["Прописка.Дом"].ToString(), wordDoc);
                        export_d("{korp}", dr["Прописка.Корпус"].ToString(), wordDoc);
                        export_d("{kv}", dr["Прописка.Квартира"].ToString(), wordDoc);

                        export_d("{mobl}", dr["Место_жительста.Область"].ToString(), wordDoc);
                        export_d("{mra}", dr["Место_жительста.Район"].ToString(), wordDoc);
                        export_d("{mnp}", dr["Место_жительста.Населенный_пункт"].ToString(), wordDoc);
                        export_d("{mul}", dr["Место_жительста.Улица"].ToString(), wordDoc);
                        export_d("{mdom}", dr["Место_жительста.Дом"].ToString(), wordDoc);
                        export_d("{mkorp}", dr["Место_жительста.Корпус"].ToString(), wordDoc);
                        export_d("{mkv}", dr["Место_жительста.Квартира"].ToString(), wordDoc);
                        
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }

                    wordDoc.SaveAs2(saveD.FileName);
                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("При экспортирование данных в файл MS Word произошла ошибка!","Ошибка экспорта данных");
                }
            }
            
        }

        private void export_d(string stubToReplace, string text, Word.Document wordDос)
        {
            var r = wordDос.Content;
            r.Find.ClearFormatting();
            r.Find.Execute(FindText: stubToReplace,  ReplaceWith: text);

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveD = new SaveFileDialog();
            saveD.Filter = "Файл MS Word 2007-2013 (*.docx)|*.docx";
            if (saveD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Reports\example.docx");

                    export_d("{status}", "уволенного от " + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[6].Value.ToString().Remove(10), wordDoc);
                    export_d("{vpr}", "Приказ об увольнении:", wordDoc);
                    export_d("{pr}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[7].Value.ToString(), wordDoc);
                    export_d("{tab_n}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString(), wordDoc);
                    export_d("{fam}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString(), wordDoc);
                    export_d("{name}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString(), wordDoc);
                    export_d("{otch}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[3].Value.ToString(), wordDoc);
                    export_d("{dr}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[4].Value.ToString().Remove(10), wordDoc);
                    export_d("{voz}", увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[5].Value.ToString(), wordDoc);

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\DataBase_sotrudniki.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT Должность.[Основная должность], Должность.[Дополнительная должность], Должность.[Дополнительная должность на предприятиии], Должность.[Место работы по совместительству], Паспорт.[Серия], Паспорт.[Номер], Паспорт.[Личный номер паспорта], Паспорт.[Кем выдан], Паспорт.[Гражданство], Паспорт.[Дата выдачи], Паспорт.[Срок действия], Прописка.[Область], Прописка.[Район], Прописка.[Населенный_пункт], Прописка.[Улица], Прописка.[Дом], Прописка.[Корпус], Прописка.[Квартира],Место_жительста.[Область], Место_жительста.[Район], Место_жительста.[Населенный_пункт], Место_жительста.[Улица], Место_жительста.[Дом], Место_жительста.[Корпус], Место_жительста.[Квартира]  FROM Увольнение, Должность, Паспорт, Прописка, Место_жительста WHERE Увольнение.Табельный_номер = Должность.Табельный_номер AND Должность.Табельный_номер = Паспорт.[Табельный номер] AND Паспорт.[Табельный номер] = Прописка.Табельный_номер AND Прописка.Табельный_номер = Место_жительста.Табельный_номер AND Увольнение.Табельный_номер=" + увольнениеDataGridView.Rows[увольнениеDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString() + ";";

                    try
                    {

                        connection.Open();
                        OleDbDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                export_d("{dol}", dr["Основная должность"].ToString(), wordDoc);
                                export_d("{ddol}", dr["Дополнительная должность"].ToString(), wordDoc);
                                export_d("{mdr}", dr["Место работы по совместительству"].ToString(), wordDoc);
                                export_d("{ser}", dr["Серия"].ToString(), wordDoc);
                                export_d("{nom}", dr["Номер"].ToString(), wordDoc);
                                export_d("{lich}", dr["Личный номер паспорта"].ToString(), wordDoc);
                                export_d("{kem_v}", dr["Кем выдан"].ToString(), wordDoc);
                                export_d("{gr}", dr["Гражданство"].ToString(), wordDoc);
                                export_d("{kog}", dr["Дата выдачи"].ToString().Remove(10), wordDoc);
                                export_d("{srok}", dr["Срок действия"].ToString().Remove(10), wordDoc);

                                export_d("{obl}", dr["Прописка.Область"].ToString(), wordDoc);
                                export_d("{ra}", dr["Прописка.Район"].ToString(), wordDoc);
                                export_d("{np}", dr["Прописка.Населенный_пункт"].ToString(), wordDoc);
                                export_d("{ul}", dr["Прописка.Улица"].ToString(), wordDoc);
                                export_d("{dom}", dr["Прописка.Дом"].ToString(), wordDoc);
                                export_d("{korp}", dr["Прописка.Корпус"].ToString(), wordDoc);
                                export_d("{kv}", dr["Прописка.Квартира"].ToString(), wordDoc);

                                export_d("{mobl}", dr["Место_жительста.Область"].ToString(), wordDoc);
                                export_d("{mra}", dr["Место_жительста.Район"].ToString(), wordDoc);
                                export_d("{mnp}", dr["Место_жительста.Населенный_пункт"].ToString(), wordDoc);
                                export_d("{mul}", dr["Место_жительста.Улица"].ToString(), wordDoc);
                                export_d("{mdom}", dr["Место_жительста.Дом"].ToString(), wordDoc);
                                export_d("{mkorp}", dr["Место_жительста.Корпус"].ToString(), wordDoc);
                                export_d("{mkv}", dr["Место_жительста.Квартира"].ToString(), wordDoc);

                            }

                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
                    }

                    wordDoc.SaveAs2(saveD.FileName);
                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("При экспортирование данных в файл MS Word произошла ошибка!", "Ошибка экспорта данных");
                }
            }
        }

        private void увольнениеDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
