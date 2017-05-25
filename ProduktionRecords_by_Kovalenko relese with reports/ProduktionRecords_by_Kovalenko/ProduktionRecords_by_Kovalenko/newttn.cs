using System;
using System.Data.OleDb;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class newttn : Form
    {
        public newttn()
        {
            InitializeComponent();
        }

        private int get_ttn_id()
        {
            int id = 0;
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT MAX(otg_ttn.[ID]) FROM otg_ttn; ";
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            id = (int)dr[0];
                        }
                        catch
                        {
                            id = 0;
                        }
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            } 
                return id;
        }

        private int get_nn_id()
        {
            int id = 0;
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT MAX(id) FROM n_in_otg; ";
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            id = (int)dr[0];
                        }
                        catch
                        {
                            id = 0;
                        }
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
            return id;
        }

        private bool exist(int ig)
        {
            string x="";
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT n_in_otg.[id] FROM n_in_otg where n_in_otg.[id_otg]="+tid+" and n_in_otg.[id]="+ig+";";
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows == true)
                {
                   x= dr[0].ToString();
                }
                else
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
            if (x != "") return true; else return false;
        }

        private void delete_n(int id)
        {

            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Delete  From n_in_otg where id = "+id+";";
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошбика удаления: нет доступа к базе данных или заданны неверные параметры удаления! \n\n Описание ошибки:" + ex, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                connection.Close();
            }


        private void load_ch()
        {
            
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT otg_ttn.ID, otg_ttn.Date_otg, kontraagets.Name_org, agreements.Name, sklad.Name FROM sklad INNER JOIN ((kontraagets INNER JOIN agreements ON kontraagets.ID = agreements.ID_kontagent) INNER JOIN otg_ttn ON agreements.ID = otg_ttn.agr) ON sklad.Код = otg_ttn.Sklad Where otg_ttn.ID = "+tid+";";
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            label1.Text = dr[0].ToString();
                            dateTimePicker1.Value = Convert.ToDateTime(dr[1].ToString());
                            textBox1.Text = dr[2].ToString();
                            textBox2.Text = dr[3].ToString();
                            textBox3.Text = dr[4].ToString();
                          
                        }
                        catch
                        {

                        }
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
        }

        private void load_tab()
        {
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT n_in_otg.id, n_in_otg.nomek, nomenclature.Name, n_in_otg.kol, nomenclature.Cost, nomenclature.NDS FROM otg_ttn INNER JOIN (nomenclature INNER JOIN n_in_otg ON nomenclature.ID = n_in_otg.nomek) ON otg_ttn.ID = n_in_otg.id_otg where id_otg = " + tid+"; ";
            int c = 0;
            dataGridView1.Rows.Clear();
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[c].Cells[8].Value = dr[0].ToString();
                            dataGridView1.Rows[c].Cells[0].Value = dr[1].ToString();
                            dataGridView1.Rows[c].Cells[1].Value = dr[2].ToString();
                            dataGridView1.Rows[c].Cells[2].Value = dr[4].ToString();
                            dataGridView1.Rows[c].Cells[3].Value = dr[3].ToString();
                            dataGridView1.Rows[c].Cells[5].Value = dr[5].ToString();
                            var zn = dataGridView1.Rows[c].Cells[2];
                            var kol = dataGridView1.Rows[c].Cells[3];
                            var sum = dataGridView1.Rows[c].Cells[4];
                            var st_nds = dataGridView1.Rows[c].Cells[5];
                            var nds = dataGridView1.Rows[c].Cells[6];
                            var all = dataGridView1.Rows[c].Cells[7];
                            sum.Value = Convert.ToInt32(zn.Value) * Convert.ToInt32(kol.Value);
                            nds.Value = Convert.ToInt32(sum.Value) / 100 * Convert.ToInt32(st_nds.Value);
                            all.Value = Convert.ToInt32(sum.Value) + Convert.ToInt32(sum.Value) / 100 * Convert.ToInt32(st_nds.Value);
                            c++;
                        }
                        catch
                        {

                        }
                    }

                }
                connection.Close();
                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
        }

        public static int k_id { get; set; }
        public static string k_name { get; set; }
        public static int d_id { get; set; }
        public static string d_name { get; set; }
        public static int s_id { get; set; }
        public static string s_name { get; set; }

        public static int n_id { get; set; }
        public static string n_name { get; set; }
        public static int n_zn { get; set; }
        public static int n_nds { get; set; }
        public static int tid { get; set; }

        public static bool editflag;

        private void newttn_Load(object sender, EventArgs e)
        {
            if (editflag != true)
            {
                label1.Text = (get_ttn_id() + 1).ToString();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
            }
            else
            {
                
                label1.Text = tid.ToString();
                load_ch();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                load_tab();
            }
            
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           DialogResult d = MessageBox.Show("Вы действительно хотите отменить отгрузку товара? Все несахраненные данные будут потеряны!", "Закрыть окно", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kontragent n = new kontragent();
            n.Text = "Контрагенты";
            kontragent.edit_flag = true;
            n.ShowDialog();
            textBox1.Text = k_name;
            kontragent.edit_flag = false;
            textBox2.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doc n = new Doc();
            n.Text = "Договора";
            Doc.edit_flag = true;
            n.ShowDialog();
            textBox2.Text = d_name;
            Doc.edit_flag = false;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            button3_Click(sender,e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sklad n = new sklad();
            n.Text = "Склады";
            sklad.edit_flag = true;
            n.ShowDialog();
            textBox3.Text = s_name;
            sklad.edit_flag = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cellcount = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                if (cellcount != dataGridView1.CurrentCell)
                {
                    Nom n = new Nom();
                    n.Text = "Номенклатура";
                    Nom.edit_flag = true;
                    n.ShowDialog();
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value = n_id;
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value = n_name;
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value = n_zn;
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value = n_nds;
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = 1;
                    Nom.edit_flag = false;
                }
            }
            catch
            { }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Rows.Add();
            }

            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                   
                        
                        var c = dataGridView1.CurrentRow;
                        c.Selected = true;
                        if (dataGridView1.CurrentRow.Cells[8].Value != null)
                        {
                            delete_n(Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value));
                        }
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);

                    
                }
                catch { }
                finally { update(); }
            }
        }

      

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (dataGridView1.CurrentRow != null)
            {
                    
                        
                        var zn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2];
                        var kol = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                        var sum = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4];
                        var st_nds = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5];
                        var nds = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6];
                        var all = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7];
                        sum.Value = Convert.ToInt32(zn.Value) * Convert.ToInt32(kol.Value);
                        nds.Value = Convert.ToInt32(sum.Value) / 100 * Convert.ToInt32(st_nds.Value);
                        all.Value = Convert.ToInt32(sum.Value) + Convert.ToInt32(sum.Value) / 100 * Convert.ToInt32(st_nds.Value);
                    update();
                    
            }
        }
            catch
            {

            }

        }

        private void insert()
        {
            int max = get_nn_id();

            max++;
            var dt = dataGridView1.Rows;
            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string d = dateTimePicker1.Value.ToString("dd/MM/yyyy").Replace('.', '/');
            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO otg_ttn Values (" + label1.Text + ", #" + d + "# ," + k_id + "," + d_id + "," + s_id + "," + label8.Text + ");";
                command.ExecuteNonQuery();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    command.CommandText = "INSERT INTO n_in_otg Values (" + max + "," + label1.Text + "," + dt[i].Cells[0].Value.ToString() + "," + dt[i].Cells[3].Value.ToString() + "," + dt[i].Cells[4].Value.ToString() + ");";
                    command.ExecuteNonQuery();
                    max++;
                }
                connection.Close();
                load_tab();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int cc = get_nn_id() + 1;
            tid = Convert.ToInt32(label1.Text);
            DialogResult dialog = MessageBox.Show("Записать изменения?", "Записать изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes && validate_form() == true)
            {
                if (editflag == false) { insert(); editflag = true; }
                else
                {
                    var dt = dataGridView1.Rows;
                    string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
                    OleDbConnection connection = new OleDbConnection(connStr);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string d = dateTimePicker1.Value.ToString("dd/MM/yyyy").Replace('.', '/');
                    try
                    {
                        connection.Open();                      
                        command.CommandText = "UPDATE otg_ttn SET Date_otg = #" + d + "#, Kontrg = " + k_id + " , agr = " + d_id + ", Sklad=" + s_id + ", otg_ttn.[All]=" + label8.Text + " Where ID = " + label1.Text + ";";
                        command.ExecuteNonQuery();
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dt[i].Cells[8].Value != null)
                            {
                                command.CommandText = "UPDATE n_in_otg SET [id_otg] = " + label1.Text + ", [nomek] =" + dt[i].Cells[0].Value.ToString() + ", [kol] = " + dt[i].Cells[3].Value.ToString() + " , [sum] = " + dt[i].Cells[4].Value.ToString() + " Where [id] = " + dt[i].Cells[8].Value.ToString() + " and [id_otg] = " + label1.Text + ";";
                                command.ExecuteNonQuery();
                            }
                            else
                            {
                                command.CommandText = "INSERT INTO n_in_otg Values (" + cc + "," + label1.Text + "," + dt[i].Cells[0].Value.ToString() + "," + dt[i].Cells[3].Value.ToString() + "," + dt[i].Cells[4].Value.ToString() + ");";
                                command.ExecuteNonQuery();
                                cc++;
                            }
                        }
                        connection.Close();
                        load_tab();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
                    }

                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveD = new SaveFileDialog();
            //saveD.Filter = "Файл MS Word 2007-2016 (*.docx)|*.docx";

            //if (saveD.ShowDialog() == DialogResult.OK)
            //{
                try
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;

                    var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Res\example.dotx");
                    export_d("{id}", label1.Text, wordDoc);
                    export_d("{dt_otg}", dateTimePicker1.Value.ToString("dd/MM/yyyy"), wordDoc);
                    export_d("{kontr}", textBox1.Text, wordDoc);
                    export_d("{argen}", textBox2.Text, wordDoc);
                    export_d("{skld}", textBox3.Text, wordDoc);

                    object missing = Type.Missing;
                    Word.Table tbl = wordApp.ActiveDocument.Tables[2];
                    int ii = 2;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        tbl.Rows.Add(ref missing);
                        tbl.Cell(ii, 1).Range.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        tbl.Cell(ii, 2).Range.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        tbl.Cell(ii, 3).Range.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        tbl.Cell(ii, 4).Range.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        tbl.Cell(ii, 5).Range.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        tbl.Cell(ii, 6).Range.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        tbl.Cell(ii, 7).Range.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        tbl.Cell(ii, 8).Range.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        ii++;

                    }
                    tbl.Cell(ii, 1).Range.Bold = 1;
                    tbl.Cell(ii, 8).Range.Bold = 1;
                    tbl.Cell(ii, 1).Range.Text = "Итого:";
                    tbl.Cell(ii, 8).Range.Text = label8.Text;
                    wordDoc.SaveAs2(Application.StartupPath + @"\temp\print.docx");
                    wordDoc.PrintPreview();
                    wordApp.Visible = true;

                }
                catch
                {

                }
            //}
        }



        #region "Финал"
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void newttn_FormClosing(object sender, FormClosingEventArgs e)
        {
            editflag = false;
        }

        private void newttn_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private bool validate_form()
        {
            if (k_id != 0 || d_id != 0 || s_id != 0)
            {
                return true;
            }
            else return false;
        }

        private void update()
        {
            int sum_all = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                try
                {
                    sum_all += (int)row.Cells["c7"].Value;
                }
                catch
                {

                }
            label8.Text = sum_all.ToString();
        }

        #endregion

        private void export_d(string stubToReplace, string text, Word.Document wordDос)
        {
            var r = wordDос.Content;
            r.Find.ClearFormatting();
            r.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void label6_Click(object sender, EventArgs e)
        {
         
          
            }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveD = new SaveFileDialog();
            saveD.Filter = "Файл MS Word 2007-2016 (*.docx)|*.docx";

            if (saveD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;

                    var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Res\example.dotx");
                    export_d("{id}", label1.Text, wordDoc);
                    export_d("{dt_otg}", dateTimePicker1.Value.ToString("dd/MM/yyyy"), wordDoc);
                    export_d("{kontr}", textBox1.Text, wordDoc);
                    export_d("{argen}", textBox2.Text, wordDoc);
                    export_d("{skld}", textBox3.Text, wordDoc);

                    object missing = Type.Missing;
                    Word.Table tbl = wordApp.ActiveDocument.Tables[2];
                    int ii = 2;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        tbl.Rows.Add(ref missing);
                        tbl.Cell(ii, 1).Range.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        tbl.Cell(ii, 2).Range.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        tbl.Cell(ii, 3).Range.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        tbl.Cell(ii, 4).Range.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        tbl.Cell(ii, 5).Range.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        tbl.Cell(ii, 6).Range.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        tbl.Cell(ii, 7).Range.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        tbl.Cell(ii, 8).Range.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        ii++;
                        
                    }
                    tbl.Cell(ii, 1).Range.Bold = 1;
                    tbl.Cell(ii, 8).Range.Bold = 1;
                    tbl.Cell(ii, 1).Range.Text = "Итого:";
                    tbl.Cell(ii, 8).Range.Text = label8.Text;
                    
                    wordDoc.SaveAs2(saveD.FileName);
                    wordApp.Visible = true;
                }
                catch
                {

                }
            }
    }
    }
}
