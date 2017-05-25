using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aquapark
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "Пользовательские методы"

            public void dtgridUptate()
            {
                var dt = dataGridView1;
                dt.Rows.Clear();
                DB.com.Connection = DB.con;
                DB.con.Open();
                DB.com.CommandText = @"Select * From Clients";
                var dr = DB.com.ExecuteReader();
                var date = new DateTime();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dt.Rows.Add();
                        dt.Rows[dt.RowCount-1].Cells[0].Value = dr[0].ToString();
                        dt.Rows[dt.RowCount-1].Cells[1].Value = dr[2].ToString();
                        dt.Rows[dt.RowCount-1].Cells[2].Value = dr[1].ToString();
                        dt.Rows[dt.RowCount-1].Cells[3].Value = dr[3].ToString();
                        date = Convert.ToDateTime(dr[4]);
                        dt.Rows[dt.RowCount - 1].Cells[4].Value = date.ToString("dd/MM/yyyy");
                    }
                    dr.Close();
                }
                DB.con.Close();
            }

            private int get_id(DataGridView g)
            {
                try
                {
                    return Convert.ToInt32(g.Rows[g.CurrentRow.Index].Cells[0].Value);
                }
                catch
                {
                    return 0;
                }
            }

        private string get_id(DataGridView g, byte i)
        {
            try
            {
                return g.Rows[g.CurrentRow.Index].Cells[i].Value.ToString();
            }
            catch
            {
                return "";
            }
        }

        #endregion

        private System.Drawing.Printing.PrintDocument docToPrint =
                new System.Drawing.Printing.PrintDocument();

        private void Form1_Load(object sender, EventArgs e)
        {
            id_client = 0;
            this.Text = "Автоматизированая система продажи билетов"; 
            dtgridUptate(); 
        }

        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont =
                new Font("Arial", 26, FontStyle.Regular);
            System.Drawing.Font printFontBold =
                new Font("Arial", 26, FontStyle.Bold);

            e.Graphics.DrawString(Program.org_name, printFont,
                Brushes.Black, 10, 10);
            e.Graphics.DrawString("УНП " + Program.org_unp, printFont,
                Brushes.Black, 10, 50);
            e.Graphics.DrawString("Касссир: " + Program.teller_name, printFont,
                Brushes.Black, 10, 100);
            e.Graphics.DrawString("Клиент: " + StrClient, printFont,
                Brushes.Black, 10, 150);
            e.Graphics.DrawString("Тип биллета: " + type_of_ticket, printFont,
                Brushes.Black, 10, 200);
            e.Graphics.DrawString("Сумма: " +label4.Text, printFontBold,
                Brushes.Black, 10, 250);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = new DialogResult();
            
            if (get_id(dataGridView1) != 0)
            {
                d = MessageBox.Show("Вы действительно хотите удалить клиента?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (d == DialogResult.Yes)
                {
                    DB.com.Connection = DB.con;
                    DB.com.CommandText = @"DELETE FROM Ticketing WHERE Ticketing.Client =" + get_id(dataGridView1).ToString() + "; "
                                        + "Delete from Privileges Where ID_client = " + get_id(dataGridView1).ToString() + "; "
                                        + "Delete from Clients Where ID_Client = " + get_id(dataGridView1).ToString() + "; ";
                    DB.con.Open();
                    DB.com.ExecuteNonQuery();
                    DB.con.Close();
                    dtgridUptate();
                }
            }
            else
            {
                MessageBox.Show("Не выбран элемент из таблицы", "Ошибка элемента таблицы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult d = new DialogResult();
            
            if (get_id(dataGridView1) != 0)
            {
                d = MessageBox.Show("Вы действительно хотите изменить данные о клиенте?", "Изменение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    var n = new Add_EditForm();
                    n.Text = "Изменение данных о пользователе";
                    n.edit = true;
                    n.id_clinet = get_id(dataGridView1);
                    n.n_client = get_id(dataGridView1, 2);
                    n.f_client = get_id(dataGridView1, 1);
                    n.r_client = get_id(dataGridView1, 3);
                    n.d_client = Convert.ToDateTime(get_id(dataGridView1, 4));
                    n.ShowDialog();
                    dtgridUptate();
                }
            }
            else
            {
                MessageBox.Show("Не выбран элемент из таблицы", "Ошибка элемента таблицы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var n = new Add_EditForm();
            n.Text = "Добавление пользователя";
            n.edit = false;    
            n.ShowDialog();
            dtgridUptate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt = dataGridView1;
            dt.Rows.Clear();
            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"Select * From Clients Where Surname like'" + textBox2.Text + "%' ;";
            var dr = DB.com.ExecuteReader();
            var date = new DateTime();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add();
                    dt.Rows[dt.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[1].Value = dr[2].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    date = Convert.ToDateTime(dr[4]);
                    dt.Rows[dt.RowCount - 1].Cells[4].Value = date.ToString("dd/MM/yyyy");
                }
                dr.Close();
            }
            DB.con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dtgridUptate();
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                button6.Visible = true;
            else button6.Visible = false;
        }

        public static int id_client;
        public static int tick_id;
        public static string StrClient;
        public static DateTime VClient;
        public static string type_of_ticket;

        private int YearS(DateTime d)
        {
            int years = DateTime.Now.Year - d.Year;
            if (DateTime.Now.Month < d.Month ||
                (DateTime.Now.Month == d.Month &&
                 DateTime.Now.Day < d.Day))
            {
                years--;
            }
            return years;
        }

        private int get_client_benefit(int nclient)
        {
            int bef = 0;

            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"SELECT b.Sale"
                                 + " FROM Privileges AS p" 
	                             + " INNER JOIN benefits AS b ON"
	                             + " p.ID_benefit = b.ID_benefit"
                                 + " Where p.ID_client = " + nclient + ";";
            var dr = DB.com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    bef += (int)dr[0];
                }
                dr.Close();
            }

            DB.con.Close();

            return bef;
        }
        private int get_cost(int years)
        {
            int cost = 0;
            int id = 1;
            type_of_ticket = "Детский";
            if (years >= 18 && years <= 60) { id = 2; type_of_ticket = "Взрослый"; }
            if (years > 60) { id = 3; type_of_ticket = "Пенсионный"; }
            DB.com.Connection = DB.con;
            DB.con.Open();
            DB.com.CommandText = @"SELECT t.Cost, t.ID_ticket "
                                 + " FROM Type_of_tikets AS t"
                                 + " Where t.ID_ticket = "+ id +";";
            var dr = DB.com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cost = (int)dr[0];
                    tick_id = (int)dr[1];
                }
                dr.Close();
            }
            DB.con.Close();
            return cost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var n = new Clients();
            int bef = 0;
            int years = YearS(VClient);
            n.ShowDialog();
            if (id_client != 0)
            {
                textBox1.Text = StrClient;
                bef = get_client_benefit(id_client);
                if (bef > 100)
                {
                    bef = 100;
                }

                int final_cost = get_cost(years);
                final_cost -= (int)(final_cost / 100 * bef);
                label4.Text = final_cost.ToString();
                docToPrint.DocumentName = Application.StartupPath + "\\tickets\\Text.txt";
                printPreviewControl1.Document = docToPrint;
                this.docToPrint.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(
                docToPrint_PrintPage);
                
                

                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    DB.com.Connection = DB.con;
                    DB.com.CommandText = @"INSERT INTO Ticketing Values ('"
                                          + id_client + "','"
                                          + tick_id + "','"
                                          + Program.teller_id + "','"
                                          + DateTime.Now.ToString("dd.MM.yyyy") + "',"
                                          + Convert.ToInt32(label4.Text) + ");";
                    DB.con.Open();
                    DB.com.ExecuteNonQuery();
                    DB.con.Close();

                    printPreviewControl1.Document.Print();
                }
            }
            catch
            {
                MessageBox.Show("Не выбран клиент!", "Ошибка печати", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new AboutBox1();
            n.ShowDialog();
        }

        private void настройкаПринтераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printPreviewControl1.Document;
            printDialog1.ShowDialog();
        }

        private void настройкиПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }

        private void базаКассировToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rep = new Reports();
            rep.ShowDialog();
        }

        private void добавитьНовогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tel = new AddTeller();
            tel.edit = false;
            tel.ShowDialog();
        }

        private void изменитьИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new AddTeller();
            n.Text = "Изменение информации о кассире";
            n.edit = true;
            n.ShowDialog();
        }
    }
}
