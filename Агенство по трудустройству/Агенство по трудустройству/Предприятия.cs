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
    public partial class Предприятия : Form
    {
        public Предприятия()
        {
            InitializeComponent();
        }

        private void предприятияBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.предприятияBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void Предприятия_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Предприятия". При необходимости она может быть перемещена или удалена.
            this.предприятияTableAdapter.Fill(this.деденко_курсачDataSet.Предприятия);

        }
    }
}
