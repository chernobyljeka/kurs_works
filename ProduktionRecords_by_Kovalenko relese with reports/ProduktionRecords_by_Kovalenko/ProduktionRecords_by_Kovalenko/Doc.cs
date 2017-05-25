using System;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class Doc : Form
    {
        public Doc()
        {
            InitializeComponent();
        }

        public static bool edit_flag = false;

        private void agreementsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.agreementsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_uchetkaaccdbDataSet);

        }

        private void Doc_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.kontraagets". При необходимости она может быть перемещена или удалена.
            this.kontraagetsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.kontraagets);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.agreements". При необходимости она может быть перемещена или удалена.
            this.agreementsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.agreements);
            if (edit_flag == true)
            {
                agreementsBindingSource.Filter = string.Format("ID_kontagent = {0}", newttn.k_id.ToString());
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.agreementsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            }
            catch
            {
                
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                agreementsBindingSource.Filter = string.Format("Name LIKE '{0}*'", this.toolStripTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Поиск", "Поиск не дал результатов!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void agreementsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (edit_flag == true)
                {
                    var c1 = agreementsDataGridView.Rows[agreementsDataGridView.CurrentRow.Index].Cells[0];
                    var c2 = agreementsDataGridView.Rows[agreementsDataGridView.CurrentRow.Index].Cells[1];
                    if (c2.Value.ToString() != "")
                    {
                        newttn.d_id = (int)c1.Value;
                        newttn.d_name = c2.Value.ToString();
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
