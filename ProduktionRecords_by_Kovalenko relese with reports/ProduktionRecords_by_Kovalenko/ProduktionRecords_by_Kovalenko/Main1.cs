using System;
using System.Windows.Forms;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class Main1 : Form
    {
        public Main1()
        {
            InitializeComponent();
        }
    


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {      
                Application.Exit();
        }

        private void номенклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nom childForm = new Nom();
            childForm.MdiParent = this;
            childForm.Text = "Наменклатура";
            childForm.Show();
        }

        private void договораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doc childForm = new Doc();
            childForm.MdiParent = this;
            childForm.Text = "Договора";
            childForm.Show();
        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kontragent childForm = new kontragent();
            childForm.MdiParent = this;
            childForm.Text = "Контрагенты";
            childForm.Show();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sklad childForm = new sklad();
            childForm.MdiParent = this;
            childForm.Text = "Склады";
            childForm.Show();
        }

    

        private void Main_Load(object sender, EventArgs e)
        {
          
        }

        private void отгрузитьТоварToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newttn.editflag = false;
            newttn childForm = new newttn();
            childForm.MdiParent = this;
            childForm.Text = "Отгрузить товар";
            childForm.Show();
        }

        private void журналОтгрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalttn childForm = new journalttn();
            childForm.MdiParent = this;
            childForm.Text = "Журнал отгрузок товара";
            childForm.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Вы действительно хотите закрыть программу?\nВсе несахраненные данные будут потеряны!", "Выход из программы", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void заПериодПоКонтрагентуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportbykontragents childForm = new reportbykontragents();
            childForm.MdiParent = this;
            childForm.Text = "Формирование отчета за период по контрагенту";
            childForm.Show();
        }

        private void поКонтрагентуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportbydate childForm = new reportbydate();
            childForm.MdiParent = this;
            childForm.Text = "Формирование отчета за период";
            childForm.Show();
        }
    }
}
