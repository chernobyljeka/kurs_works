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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "Кутукин1DataSet.Report". При необходимости она может быть перемещена или удалена.
            this.ReportTableAdapter.Fill(this.Кутукин1DataSet.Report);

            this.reportViewer1.RefreshReport();
        }
    }
}
