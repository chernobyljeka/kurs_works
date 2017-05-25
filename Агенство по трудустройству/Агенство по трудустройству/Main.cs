using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Агенство_по_трудустройству
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void образованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Образование n = new Образование();
            n.ShowDialog();
        }

        private void сферфToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Сфера n = new Сфера();
            n.ShowDialog();
        }

        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 n = new Form1();
            n.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void вакансияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Предприятия n = new Предприятия();
            n.ShowDialog();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Должность n = new Должность();
            n.ShowDialog();
        }

        private void претендентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Претенденты n = new Претенденты();
            n.ShowDialog();
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Заявки n = new Заявки();
            n.ShowDialog();
        }

        private void поискBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.поискBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter.Fill(this.деденко_курсачDataSet.Заявки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Предприятия". При необходимости она может быть перемещена или удалена.
            this.предприятияTableAdapter.Fill(this.деденко_курсачDataSet.Предприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Претенденты". При необходимости она может быть перемещена или удалена.
            this.претендентыTableAdapter.Fill(this.деденко_курсачDataSet.Претенденты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.деденко_курсачDataSet.Должности);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Сферы". При необходимости она может быть перемещена или удалена.
            this.сферыTableAdapter.Fill(this.деденко_курсачDataSet.Сферы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Поиск". При необходимости она может быть перемещена или удалена.
            this.поискTableAdapter.Fill(this.деденко_курсачDataSet.Поиск);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Поиск". При необходимости она может быть перемещена или удалена.
            this.поискTableAdapter.Fill(this.деденко_курсачDataSet.Поиск);

        }

        private void поискBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.поискBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 n = new AboutBox1();
            n.ShowDialog();
        }

        private void поискBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void трудоустроитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string connStr = @"Password=" + Program.pas + ";User ID=" + Program.login + ";Initial Catalog=Деденко_курсач;Data Source=" + Program.server + ";Connection Timeout=3";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "seach";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            Main_Load(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            INFO n = new INFO();
     
            string z = поискDataGridView.Rows[поискDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string p = поискDataGridView.Rows[поискDataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string connStr = @"Password=" + Program.pas + ";User ID=" + Program.login + ";Initial Catalog=Деденко_курсач;Data Source=" + Program.server + ";Connection Timeout=3";
            SqlConnection conn = new SqlConnection(connStr);
            string qw = @"Select *,*, Образования.Образование, Сферы.Сфера, Должности.Должности, Предприятия.Предприятие From Претенденты, Заявки, Образования, Сферы, Должности, Предприятия  where "
                 + "Должности.ID=Претенденты.Должность and Предприятия.ID=Заявки.Предприятие and Сферы.ID=Претенденты.[Сфера деятельноти] and Образования.ID=Претенденты.Образование and Заявки.ID=" + z + " and Претенденты.ID=" + p + ";";
            SqlCommand com = new SqlCommand(qw,conn);
            
            conn.Open();
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                n.textBox1.Text = rd[1].ToString();
                n.textBox2.Text = rd[2].ToString();
                n.textBox3.Text = rd[3].ToString();
                n.textBox4.Text = rd[4].ToString();
                n.textBox5.Text = rd[18].ToString();
                n.textBox6.Text = rd[20].ToString();
                n.textBox7.Text = rd[22].ToString();
                n.textBox8.Text = rd[8].ToString();
                n.textBox9.Text = rd[9].ToString();
                n.textBox10.Text = rd[24].ToString();
                n.textBox11.Text = rd[20].ToString();
                n.textBox12.Text = rd[18].ToString();
                n.textBox13.Text = rd[22].ToString();
                n.textBox14.Text = rd[15].ToString();
                n.textBox15.Text = rd[16].ToString();

            }
            n.label1.Text = "Претендент №"+p+" на заяку №"+z;
            conn.Close();
            n.ShowDialog();
        }

        private void поискDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int r = поискDataGridView.CurrentCell.RowIndex;
            ТР n = new ТР();
            n.Show();
            n.button2.MouseDown += (sender1, e1) =>
           {
               string dat = n.dateTimePicker1.Value.ToString().Substring(6, 4) + "." + n.dateTimePicker1.Value.ToString().Substring(0, 2) + "." + n.dateTimePicker1.Value.ToString().Substring(3, 2);
               n.Close();
   string z = поискDataGridView.Rows[r].Cells[1].Value.ToString();
            string p = поискDataGridView.Rows[r].Cells[0].Value.ToString();
            string connStr = @"Password=" + Program.pas + ";User ID=" + Program.login + ";Initial Catalog=Деденко_курсач;Data Source=" + Program.server + ";Connection Timeout=3";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "trud";
            comm.Parameters.AddWithValue("@poisk", p);
            comm.Parameters.AddWithValue("@zav", z);
            
            comm.Parameters.AddWithValue("@dat", dat);
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
           };
          
            Main_Load(sender, e);
        }


     
    }
}
