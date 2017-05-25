using System;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class Nom : Form
    {
        public Nom()
        {
            InitializeComponent();
        }

        public static bool edit_flag = false;

        private void nomenclatureBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nomenclatureBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_uchetkaaccdbDataSet);

        }

        private void Nom_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.nomenclature". При необходимости она может быть перемещена или удалена.
            this.nomenclatureTableAdapter.Fill(this.db_uchetkaaccdbDataSet.nomenclature);

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                nomenclatureBindingSource.Filter = string.Format("Name LIKE '{0}*'", this.toolStripTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Поиск не дал результатов!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nomenclatureDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (nomenclatureDataGridView.CurrentRow != null)
                {
                    var cr = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[4];
                    var c1 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[2];
                    var c2 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[3];
                    cr.Value = (int)c1.Value + (int)c1.Value / 100 * (int)c2.Value;
                }
            }
            catch
            {

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void nomenclatureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (edit_flag == true)
            {
                var c1 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[0];
                var c2 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[1];
                var c3 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[2];
                var c4 = nomenclatureDataGridView.Rows[nomenclatureDataGridView.CurrentRow.Index].Cells[3];
                if (c2.Value.ToString() != "" && c2.Value.ToString() != "")
                {
                    newttn.n_id = (int)c1.Value;
                    newttn.n_name = c2.Value.ToString();
                    newttn.n_zn = (int)c3.Value;
                    newttn.n_nds = (int)c4.Value;
                    this.Close();
                }
            }
        }

        private void nomenclatureDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
