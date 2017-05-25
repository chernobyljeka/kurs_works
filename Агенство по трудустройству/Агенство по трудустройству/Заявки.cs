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
    public partial class Заявки : Form
    {
        public Заявки()
        {
            InitializeComponent();
        }

        private void заявкиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.заявкиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }

        private void Заявки_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Претенденты". При необходимости она может быть перемещена или удалена.
            this.претендентыTableAdapter.Fill(this.деденко_курсачDataSet.Претенденты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Образования". При необходимости она может быть перемещена или удалена.
            this.образованияTableAdapter.Fill(this.деденко_курсачDataSet.Образования);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.деденко_курсачDataSet.Должности);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Сферы". При необходимости она может быть перемещена или удалена.
            this.сферыTableAdapter.Fill(this.деденко_курсачDataSet.Сферы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Предприятия". При необходимости она может быть перемещена или удалена.
            this.предприятияTableAdapter.Fill(this.деденко_курсачDataSet.Предприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter.Fill(this.деденко_курсачDataSet.Заявки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Образования". При необходимости она может быть перемещена или удалена.
            this.образованияTableAdapter.Fill(this.деденко_курсачDataSet.Образования);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.деденко_курсачDataSet.Должности);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Сферы". При необходимости она может быть перемещена или удалена.
            this.сферыTableAdapter.Fill(this.деденко_курсачDataSet.Сферы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Предприятия". При необходимости она может быть перемещена или удалена.
            this.предприятияTableAdapter.Fill(this.деденко_курсачDataSet.Предприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "деденко_курсачDataSet.Заявки". При необходимости она может быть перемещена или удалена.
            this.заявкиTableAdapter.Fill(this.деденко_курсачDataSet.Заявки);

        }

        private void заявкиBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.заявкиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.деденко_курсачDataSet);

        }
    }
}
