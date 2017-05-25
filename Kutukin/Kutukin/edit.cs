using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutukin
{
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void edit_Load(object sender, EventArgs e)
        {
            Program.read_bd("SELECT Фамилия FROM Клиент", "Фамилия");
            comboBox1.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("SELECT Услуга FROM Услуги", "Услуга");
            comboBox2.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("SELECT [Вид техники] FROM [Вид техники]", "Вид техники");
            comboBox3.DataSource = Program.tmp;
            Program.tmp.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
