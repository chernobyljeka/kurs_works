using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Aquapark
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                button6.Visible = true;
            else button6.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void gt_load()
        {
            var dt = dataGridView1;
            dt.Rows.Clear();

            DB.com.Connection = DB.con;
            DB.com.CommandText = @"SELECT Tick.ID_sell, c.Name, c.Surname, c.Patromic, ty.Discriprion, tel.FIO, Tick.Date_of_selling, Tick.Sum "
                                 + "FROM Ticketing AS Tick "
                                 + "INNER JOIN Clients AS c ON Tick.Client = c.ID_Client "
		                         + "INNER JOIN Tellers As tel ON Tick.Teller = tel.ID_teller "
                                 + "INNER JOIN Type_of_tikets As ty ON Tick.Type_of_ticket = ty.ID_ticket;";
            DB.con.Open();
            var dr = DB.com.ExecuteReader();
            var d = new DateTime();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add();
                    dt.Rows[dt.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[1].Value = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[2].Value = dr[4].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[3].Value = dr[5].ToString();
                    d = Convert.ToDateTime(dr[6]);
                    dt.Rows[dt.RowCount - 1].Cells[4].Value = d.ToString("dd.MM.yyyy");
                    dt.Rows[dt.RowCount - 1].Cells[5].Value = dr[7];
                    
                }
                dr.Close();
            }
            DB.con.Close();
        }

        private void gt_load(string str_seach)
        {
            var dt = dataGridView1;
            dt.Rows.Clear();

            DB.com.Connection = DB.con;
            DB.com.CommandText = @"SELECT Tick.ID_sell, c.Name, c.Surname, c.Patromic, ty.Discriprion, tel.FIO, Tick.Date_of_selling, Tick.Sum "
                                 + "FROM Ticketing AS Tick "
                                 + "INNER JOIN Clients AS c ON Tick.Client = c.ID_Client "
                                 + "INNER JOIN Tellers As tel ON Tick.Teller = tel.ID_teller "
                                 + "INNER JOIN Type_of_tikets As ty ON Tick.Type_of_ticket = ty.ID_ticket "
                                 + "WHERE c.Surname like '"+ str_seach +"%';";
            DB.con.Open();
            var dr = DB.com.ExecuteReader();
            var d = new DateTime();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add();
                    dt.Rows[dt.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[1].Value = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[2].Value = dr[4].ToString();
                    dt.Rows[dt.RowCount - 1].Cells[3].Value = dr[5].ToString();
                    d = Convert.ToDateTime(dr[6]);
                    dt.Rows[dt.RowCount - 1].Cells[4].Value = d.ToString("dd.MM.yyyy");
                    dt.Rows[dt.RowCount - 1].Cells[5].Value = dr[7];

                }
                dr.Close();
            }
            DB.con.Close();
        }

        private void exp_ms_word_all()
        {
            var dt = dataGridView1;
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Reports\rep_total.dotx");
            object missing = Type.Missing;
            Word.Table tbl = wordApp.ActiveDocument.Tables[1];
            int i_word = 2;
            long total = 0;
            for (int i = 0; i < dt.RowCount; i++)
            {
               if (i != dt.RowCount-1)
                    tbl.Rows.Add(ref missing);
                tbl.Cell(i_word, 1).Range.Text = dt.Rows[i].Cells[0].Value.ToString();
                tbl.Cell(i_word, 2).Range.Text = dt.Rows[i].Cells[1].Value.ToString();
                tbl.Cell(i_word, 3).Range.Text = dt.Rows[i].Cells[2].Value.ToString();
                tbl.Cell(i_word, 4).Range.Text = dt.Rows[i].Cells[3].Value.ToString();
                tbl.Cell(i_word, 5).Range.Text = dt.Rows[i].Cells[4].Value.ToString();
                tbl.Cell(i_word, 6).Range.Text = dt.Rows[i].Cells[5].Value.ToString();
                total += (int)dt.Rows[i].Cells[5].Value;
                i_word++;
            }
            export_d("{org_name}", Program.org_name, wordDoc);
            export_d("{org_unp}", Program.org_unp, wordDoc);
            export_d("{total_sum}", total.ToString(), wordDoc);
            export_d("{date}", DateTime.Now.ToString("dd.MM.yyyy"), wordDoc);
            wordDoc.SaveAs2(Application.StartupPath + @"\temp\report_0.docx");
            wordApp.Visible = true;

        }

        private void exp_ms_word_between(DateTime s, DateTime po)
        {
            var dt = dataGridView1;
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Reports\rep_between.dotx");
            object missing = Type.Missing;
            Word.Table tbl = wordApp.ActiveDocument.Tables[1];
            int i_word = 2;
            long total = 0;
            var date = new DateTime();
            for (int i = 0; i < dt.RowCount; i++)
            {
                date = Convert.ToDateTime(dt.Rows[i].Cells[4].Value);
                if (date.Date >= s.Date && date.Date <= po.Date)
                {
                    if (i != dt.RowCount - 1)
                        tbl.Rows.Add(ref missing);
                    tbl.Cell(i_word, 1).Range.Text = dt.Rows[i].Cells[0].Value.ToString();
                    tbl.Cell(i_word, 2).Range.Text = dt.Rows[i].Cells[1].Value.ToString();
                    tbl.Cell(i_word, 3).Range.Text = dt.Rows[i].Cells[2].Value.ToString();
                    tbl.Cell(i_word, 4).Range.Text = dt.Rows[i].Cells[3].Value.ToString();
                    tbl.Cell(i_word, 5).Range.Text = dt.Rows[i].Cells[4].Value.ToString();
                    tbl.Cell(i_word, 6).Range.Text = dt.Rows[i].Cells[5].Value.ToString();
                    total += (int)dt.Rows[i].Cells[5].Value;
                    i_word++;
                }
            }
            export_d("{org_name}", Program.org_name, wordDoc);
            export_d("{org_unp}", Program.org_unp, wordDoc);
            export_d("{total_sum}", total.ToString(), wordDoc);
            export_d("{d1}", s.ToString("dd.MM.yyyy"), wordDoc);
            export_d("{d2}", po.ToString("dd.MM.yyyy"), wordDoc);
            wordDoc.SaveAs2(Application.StartupPath + @"\temp\report_1.docx");
            wordApp.Visible = true;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            gt_load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gt_load(textBox2.Text);
        }

        private void export_d(string stubToReplace, string text, Word.Document wordDос)
        {
            var r = wordDос.Content;
            r.Find.ClearFormatting();
            r.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                exp_ms_word_all();
            if (radioButton2.Checked == true)
                exp_ms_word_between(dateTimePicker1.Value, dateTimePicker2.Value);
        }
    }
}
