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
    public partial class Образование : Form
    {
        public Образование()
        {
            InitializeComponent();
        }

        private void должностиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.образованияBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void Образование_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Образования". При необходимости она может быть перемещена или удалена.
            this.образованияTableAdapter.Fill(this.деденко_курсачDataSet.Образования);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Должности". При необходимости она может быть перемещена или удалена.
        }


        private void образованияBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.образованияBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }
    }
}
