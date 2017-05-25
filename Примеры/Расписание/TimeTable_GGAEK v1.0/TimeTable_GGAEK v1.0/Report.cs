using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTable_GGAEK_v1._0
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Program.read_bd("Select Группа from Группы", "Группа");
            comboBox1.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("Select Дисциплина from Дисциплина", "Дисциплина");
            comboBox2.DataSource = Program.tmp;
            Program.tmp.Clear();
            label3.Text = "Всего часов: ";
            label4.Text = "Вычтено часов: ";
            label5.Text = "Осталось часов: ";
        }
    }
}
