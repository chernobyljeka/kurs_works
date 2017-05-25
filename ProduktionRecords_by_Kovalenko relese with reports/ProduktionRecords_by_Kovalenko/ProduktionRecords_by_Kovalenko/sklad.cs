using System;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class sklad : Form
    {
        public sklad()
        {
            InitializeComponent();
        }

        public static bool edit_flag = false;

        private void skladBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.skladBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_uchetkaaccdbDataSet);

        }

        private void sklad_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.sklad". При необходимости она может быть перемещена или удалена.
            this.skladTableAdapter.Fill(this.db_uchetkaaccdbDataSet.sklad);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                skladBindingSource.Filter = string.Format("Name LIKE '{0}*'", this.toolStripTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Поиск", "Поиск не дал результатов!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void skladDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (edit_flag == true)
                {
                    var c1 = skladDataGridView.Rows[skladDataGridView.CurrentRow.Index].Cells[0];
                    var c2 = skladDataGridView.Rows[skladDataGridView.CurrentRow.Index].Cells[1];
                    if (c2.Value.ToString() != "")
                    {
                        newttn.s_id = (int)c1.Value;
                        newttn.s_name = c2.Value.ToString();
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
