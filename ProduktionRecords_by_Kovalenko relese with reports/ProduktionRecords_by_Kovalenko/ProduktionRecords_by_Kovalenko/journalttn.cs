using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class journalttn : Form
    {
        public journalttn()
        {
            InitializeComponent();
        }

        private void otg_ttnBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.otg_ttnBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_uchetkaaccdbDataSet);

        }

        private void journalttn_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.sklad". При необходимости она может быть перемещена или удалена.
            this.skladTableAdapter.Fill(this.db_uchetkaaccdbDataSet.sklad);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.agreements". При необходимости она может быть перемещена или удалена.
            this.agreementsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.agreements);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.kontraagets". При необходимости она может быть перемещена или удалена.
            this.kontraagetsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.kontraagets);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.otg_ttn". При необходимости она может быть перемещена или удалена.
            this.otg_ttnTableAdapter.Fill(this.db_uchetkaaccdbDataSet.otg_ttn);

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newttn.editflag = false;
            newttn childForm = new newttn();
            childForm.Text = "Отгрузить товар";
            childForm.Show();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {        
            if (otg_ttnDataGridView.CurrentRow != null)
            {
                var id = otg_ttnDataGridView.Rows[otg_ttnDataGridView.CurrentRow.Index].Cells[0].Value;
                DialogResult d = MessageBox.Show("Вы дествительно хотите удалить " + id.ToString() + " отгзузку?", "Отгрузка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
                    OleDbConnection connection = new OleDbConnection(connStr);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM otg_ttn where ID = " + id + ";";
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM n_in_otg where id_otg = " + id + ";";
                    connection.Close();
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.sklad". При необходимости она может быть перемещена или удалена.
                    this.skladTableAdapter.Fill(this.db_uchetkaaccdbDataSet.sklad);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.agreements". При необходимости она может быть перемещена или удалена.
                    this.agreementsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.agreements);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.kontraagets". При необходимости она может быть перемещена или удалена.
                    this.kontraagetsTableAdapter.Fill(this.db_uchetkaaccdbDataSet.kontraagets);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "db_uchetkaaccdbDataSet.otg_ttn". При необходимости она может быть перемещена или удалена.
                    this.otg_ttnTableAdapter.Fill(this.db_uchetkaaccdbDataSet.otg_ttn);
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (otg_ttnDataGridView.CurrentRow != null)
            {
                var id = otg_ttnDataGridView.Rows[otg_ttnDataGridView.CurrentRow.Index].Cells[0].Value;
                var k_id = otg_ttnDataGridView.Rows[otg_ttnDataGridView.CurrentRow.Index].Cells[2].Value;
                var d_id = otg_ttnDataGridView.Rows[otg_ttnDataGridView.CurrentRow.Index].Cells[3].Value;
                var s_id = otg_ttnDataGridView.Rows[otg_ttnDataGridView.CurrentRow.Index].Cells[4].Value;
                DialogResult d = MessageBox.Show("Вы дествительно хотите изменить " + id.ToString() + " отгзузку?", "Отгрузка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    newttn.editflag = true;
                    newttn.tid = (int)id;
                    newttn.k_id = (int)k_id;
                    newttn.d_id = (int)d_id;
                    newttn.s_id = (int)s_id;
                    newttn childForm = new newttn();
                    childForm.Text = "Отгрузить товар";
                    childForm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
