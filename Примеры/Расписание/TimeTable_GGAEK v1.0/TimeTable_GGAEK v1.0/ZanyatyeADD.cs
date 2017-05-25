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
    public partial class ZanyatyeADD : Form
    {
        public ZanyatyeADD()
        {
            InitializeComponent();
        }

        private void ZanyatyeADD_Load(object sender, EventArgs e)
        {
            var subgrupp = new[] { "Вся группа", "Подгруппа №1", "Подгруппа №2" };
            var type_z = new[] { "Теоритическое занятие", "Практическое занятие", "Лабараторное занятие" };
            comboBox5.DataSource = subgrupp;
            comboBox4.DataSource = type_z;
            Program.read_bd("Select Группа from Группы", "Группа");
            comboBox1.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("Select ФИО from Преподаватель", "ФИО");
            comboBox3.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("Select Дисциплина from Дисциплина", "Дисциплина");
            comboBox2.DataSource = Program.tmp;
            Program.tmp.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
