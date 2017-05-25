using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsCenter
{
    
    public partial class DogsCenterSplashScreen : Form
    {

        Timer tmr;
        public DogsCenterSplashScreen()
        {
            InitializeComponent();
        }

        private void DogsCenterSplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = Program.splashscreen_time * 1000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
           
        }
       
        void tmr_Tick(object sender, EventArgs e)
        {
         tmr.Stop();
         Form1 mf = new Form1();
         mf.Show();
         this.Hide();
        }

        private void DogsCenterSplashScreen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
