using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Агенство_по_трудустройству
{
    public partial class Сфера : Form
    {
        public Сфера()
        {
            InitializeComponent();
        }

        private void сферыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.сферыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void Сфера_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Сферы". При необходимости она может быть перемещена или удалена.
            this.сферыTableAdapter.Fill(this.деденко_курсачDataSet.Сферы);

        }
    }
}
