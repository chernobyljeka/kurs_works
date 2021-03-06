﻿using System;
using System.Data.OleDb;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ProduktionRecords_by_Kovalenko
{
    public partial class reportbydate : Form
    {
        public reportbydate()
        {
            InitializeComponent();
        }

        private void export_d(string stubToReplace, string text, Word.Document wordDос)
        {
            var r = wordDос.Content;
            r.Find.ClearFormatting();
            r.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string d1 = dateTimePicker1.Value.ToString("MM/dd/yyyy").Replace('.', '/'); ;
            string d2 = dateTimePicker2.Value.ToString("MM/dd/yyyy").Replace('.', '/'); ;

            string connStr = Properties.Settings.Default.db_uchetkaaccdbConnectionString;
            OleDbConnection connection = new OleDbConnection(connStr);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            try
            {
                command.CommandText = "SELECT otg_ttn.Date_otg, nomenclature.Name, nomenclature.Cost, nomenclature.NDS, n_in_otg.kol, agreements.Name, sklad.Name, kontraagets.Name_org "+
                                      "FROM kontraagets INNER JOIN (sklad INNER JOIN ((agreements INNER JOIN otg_ttn ON agreements.ID = otg_ttn.agr) INNER JOIN (nomenclature INNER JOIN n_in_otg ON nomenclature.ID = n_in_otg.nomek) ON otg_ttn.ID = n_in_otg.id_otg) ON sklad.Код = otg_ttn.Sklad) ON kontraagets.ID = agreements.ID_kontagent "+
                                      "WHERE otg_ttn.Date_otg >= #"+d1+ "# and otg_ttn.Date_otg <= #" + d2+"#;";
                 
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();


                if (dr.HasRows)
                {
                    int buf = 0;
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Res\report_dt.dotx");
                    object missing = Type.Missing;
                    Word.Table tbl = wordApp.ActiveDocument.Tables[1];
                    int ii = 2;
                    int all = 0;

                    while (dr.Read())
                    {
                        tbl.Rows.Add(ref missing);
                        tbl.Cell(ii, 1).Range.Text = dr[0].ToString().Remove(10);
                        tbl.Cell(ii, 2).Range.Text = dr[7].ToString();
                        tbl.Cell(ii, 3).Range.Text = dr[5].ToString();
                        tbl.Cell(ii, 4).Range.Text = dr[6].ToString();
                        tbl.Cell(ii, 5).Range.Text = dr[1].ToString();
                        tbl.Cell(ii, 6).Range.Text = dr[2].ToString();
                        tbl.Cell(ii, 7).Range.Text = dr[4].ToString();
                        tbl.Cell(ii, 8).Range.Text = ((int)dr[2] * (int)dr[4]).ToString();
                        tbl.Cell(ii, 9).Range.Text = dr[3].ToString();
                        tbl.Cell(ii, 10).Range.Text = (((int)dr[2] * (int)dr[4]) / 100 * (int)dr[3]).ToString();
                        buf = (((int)dr[2] * (int)dr[4]) + (((int)dr[2] * (int)dr[4]) / 100 * (int)dr[3]));
                        tbl.Cell(ii, 11).Range.Text = buf.ToString();
                        all += buf;
                        ii++;
                    }
                    d1 = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    d2 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    export_d("{dt1}", d1, wordDoc);
                    export_d("{dt2}", d2, wordDoc);
                    tbl.Cell(ii, 1).Range.Bold = 1;
                    tbl.Cell(ii, 11).Range.Bold = 1;
                    tbl.Cell(ii, 1).Range.Text = "Итого:";
                    tbl.Cell(ii, 11).Range.Text = all.ToString();
                    wordDoc.SaveAs2(Application.StartupPath + @"\temp\reportbydt.docx");
                    wordApp.Visible = true;
                }
                else MessageBox.Show("Нет данных для вывода в отчет!", "Ошибка формирования отчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString(), "Ошибка получения данных");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
