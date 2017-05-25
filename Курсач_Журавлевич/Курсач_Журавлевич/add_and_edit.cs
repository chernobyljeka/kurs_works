using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Курсач_Журавлевич
{
    public partial class add_and_edit : Telerik.WinControls.UI.RadForm
    {
        public add_and_edit()
        {
            InitializeComponent();
        }

        private void add_and_edit_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new[] { "Зачет", "Экзамен", "Зачет_Экзамен", "Тест" };
        }

        private void radTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
