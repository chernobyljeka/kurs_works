using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TimeTable_GGAEK_v1._0
{
    public partial class PredmetAddcs : Form
    {
        public PredmetAddcs()
        {
            InitializeComponent();
        }
       
        private void PredmetAddcs_Load(object sender, EventArgs e)
        {
            Program.read_bd("Select Группа from Группы", "Группа");
            comboBox1.DataSource = Program.tmp;
            Program.tmp.Clear();
            Program.read_bd("Select ФИО from Преподаватель", "ФИО");
            comboBox2.DataSource = Program.tmp;
            Program.tmp.Clear();
        }

    }
}
