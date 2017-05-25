using System;
using System.Windows.Forms;

namespace Aquapark
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.org_name;
            textBox2.Text = Program.org_unp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + @"\Settings.ini", false))
            {
                file.WriteLine("No");
                file.WriteLine(textBox1.Text);
                file.WriteLine(textBox2.Text);

                Program.org_name = textBox1.Text;
                Program.org_unp = textBox2.Text;

                file.Close();
            }
            Close();
            
        }
    }
}
