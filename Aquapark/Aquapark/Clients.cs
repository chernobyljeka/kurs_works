using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private bool choise_flag;

        private void dtgridUptate()
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

        private void Clients_Load(object sender, EventArgs e)
        {
            dtgridUptate();
            choise_flag = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            var n = new Add_EditForm();
            n.Text = "Добавление пользователя";
            n.edit = false;
            n.ShowDialog();
            dtgridUptate();
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

        private void choice_client()
        {
            if (get_id(dataGridView1) != 0)
            {
                    Form1.id_client = get_id(dataGridView1);
                    Form1.StrClient = get_id(dataGridView1, 1) + " " + get_id(dataGridView1, 2) + " " + " " + get_id(dataGridView1, 3);
                    Form1.VClient = Convert.ToDateTime(get_id(dataGridView1, 4));
                    choise_flag = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            choice_client();
            Close();
        }

        private void Clients_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (choise_flag == false)
            {
                Form1.id_client = 0;
                Form1.StrClient = "";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            choice_client();
            Close();
        }
    }
}
