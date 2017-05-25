using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Агенство_по_трудустройству
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Program.login = textBox1.Text;
                Program.pas = textBox2.Text;
                Program.server = textBox3.Text;
                string connStr = @"Password=" + Program.pas + ";User ID=" + Program.login + ";Initial Catalog=Деденко_курсач;Data Source=" + Program.server + ";Connection Timeout=3";
                SqlConnection conn = new SqlConnection(connStr);

                var doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\Агенство по трудустройству.exe.config");

                // меняем атрибут
                XmlNodeList adds = doc.GetElementsByTagName("add");
                foreach (XmlNode add in adds)
                    if (add.Attributes["name"].Value == "Агенство_по_трудустройству.Properties.Settings.Деденко_курсачConnectionString")
                    {
                        add.Attributes["connectionString"].Value = @"Data Source="+Program.server+";Initial Catalog=Деденко_курсач;Persist Security Info=True;User ID="+Program.login+";Password="+ Program.pas; // новое значение
                        break;
                    }

                // сохраняем файл
                doc.Save(Application.StartupPath + @"\Агенство по трудустройству.exe.config");

                conn.Open();
                conn.Close();
                label5.Visible = false;
                Main n = new Main();
                this.Hide();
                n.Show();
            }
            catch
            {
                label5.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }
    }
}
