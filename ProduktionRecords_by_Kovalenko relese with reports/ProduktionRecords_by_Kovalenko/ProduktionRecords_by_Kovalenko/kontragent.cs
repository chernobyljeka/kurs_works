using System;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class kontragent : Form
    {
        public kontragent()
        {
            InitializeComponent();
        }

        public static bool edit_flag = false;

        private void kontraagetsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kontraagetsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_uchetkaaccdbDataSet);

        }

        private void kontragent_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.kontraagets". При необходимости она может быть перемещена или удалена.
            this.kontraagetsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.kontraagets);

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                kontraagetsBindingSource.Filter = string.Format("Name_org LIKE '{0}*'", this.toolStripTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Поиск", "Поиск не дал результатов!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kontraagetsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void kontraagetsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (edit_flag == true )
                {
                    var c1 = kontraagetsDataGridView.Rows[kontraagetsDataGridView.CurrentRow.Index].Cells[0];
                    var c2 = kontraagetsDataGridView.Rows[kontraagetsDataGridView.CurrentRow.Index].Cells[1];
                    if (c2.Value.ToString() != "")
                    {
                        newttn.k_id = (int)c1.Value;
                        newttn.k_name = c2.Value.ToString();
                        reportbykontragents.k_id = (int)c1.Value;
                        reportbykontragents.k_name = c2.Value.ToString();
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
