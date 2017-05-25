using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 

namespace Dop
{
    public partial class Form1 : Form
    {
        List<Clotes> mas;
        public Form1()
        {
            InitializeComponent();
        }

        public class Clotes
        {
            private string tm;
            private string season;
            private string type_cl;
            private int stoim;
            private string color_tk;

            public string Tm
            {
                get
                { return tm; }
                set
                { tm = value; }
            }
            public string Season
            {
                get
                {
                    return season;
                }
                set
                {
                    season = value;
                }
            }
            public string Type_cl
            {
                get
                {
                    return type_cl;
                }
                set
                {
                    type_cl = value;
                }
            }
            public int Stoim
            {
                get
                {
                    return stoim;
                }
                set
                {
                    stoim = value;
                }
            }
            public string Color_tk
            {
                get
                {
                    return color_tk;
                }
                set
                {
                    color_tk = value;
                }
            }
            public Clotes(string tm, string season, string type_cl, int stoim, string color_tk)
            {
                this.tm = tm;
                this.season = season;
                this.type_cl = type_cl;
                this.stoim = stoim;
                this.color_tk = color_tk;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mas = new List<Clotes>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            dataGridView1.Rows.Clear();
            for (int i = 0; i < mas.Count; i++)
            {
                try
                {
                    label2.Visible = false;
                    if (mas[i].Stoim > Convert.ToInt32(textBox6.Text))
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[i].Cells["Column1"].Value = mas[i].Tm;
                        dataGridView1.Rows[i].Cells["Column2"].Value = mas[i].Season;
                        dataGridView1.Rows[i].Cells["Column3"].Value = mas[i].Type_cl;
                        dataGridView1.Rows[i].Cells["Column4"].Value = mas[i].Stoim;
                        dataGridView1.Rows[i].Cells["Column5"].Value = mas[i].Color_tk;
                    }
                }
                catch
                {
                    label2.Visible = true;
                    label2.Text = "Ошибка ввода поля для сравнения!";
                }
            }
        }
        public bool isDown;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;Point a = new Point();
            if (isDown)
            {
                c.Location = this.PointToClient(Control.MousePosition);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = false;
                Clotes add_z = new Clotes(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text);
                mas.Add(add_z);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
           catch
           {
               label2.Visible = true;
                label2.Text = "Ошибка ввода стоимости!";
           }
         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
