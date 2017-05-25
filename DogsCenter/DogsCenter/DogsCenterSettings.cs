using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DogsCenter
{
    public partial class DogsCenterSettings : Form
    {
        public DogsCenterSettings()
        {

            InitializeComponent();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { Program.way = openFileDialog1.FileName; }
            textBox1.Text = Program.way;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.splashscreen_time = Convert.ToInt32(textBox2.Text);
            if ((File.Exists(textBox1.Text) == false) || (Path.GetExtension(textBox1.Text) != ".txt")) { Program.way = "database.txt"; textBox1.Text = "database.txt"; }
            else {Program.way = textBox1.Text;}
            if (Program.splashscreen_time <= 0) 
            {
                button4.Image = Properties.Resources.togleswich_off;
                Program.splashscreen = false;
                Program.splashscreen_time = 0;
                textBox2.Text = "0";
            }
            StreamWriter FileSettings = new StreamWriter("Settings.ini", false);
            FileSettings.WriteLine(Program.way);
            FileSettings.WriteLine(Program.splashscreen);
            FileSettings.WriteLine(Program.splashscreen_time);
            FileSettings.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.splashscreen == true) 
            {
             button4.Image = Properties.Resources.togleswich_off;
             Program.splashscreen = false;
             StreamWriter FileSettings = new StreamWriter("Settings.ini", false);
             FileSettings.WriteLine(Program.way);
             FileSettings.WriteLine(Program.splashscreen);
             FileSettings.WriteLine(Program.splashscreen_time);
             FileSettings.Close();
            }
            else
            {
                button4.Image = Properties.Resources.togleswich_on;
                Program.splashscreen = true;
                StreamWriter FileSettings = new StreamWriter("Settings.ini", false);
                FileSettings.WriteLine(Program.way);
                FileSettings.WriteLine(Program.splashscreen);
                FileSettings.WriteLine(Program.splashscreen_time);
                FileSettings.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DogsCenterSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.way;
            textBox2.Text = Convert.ToString(Program.splashscreen_time);
            if (Program.splashscreen == true)
            {
                button4.Image = Properties.Resources.togleswich_on;
            }
            else
            {
                button4.Image = Properties.Resources.togleswich_off;
            } 
        }
    }
}
