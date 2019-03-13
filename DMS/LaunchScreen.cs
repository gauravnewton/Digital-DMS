using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace DMS
{

    public partial class LaunchScreen : MetroForm
    {
        static Random Rnd = new Random();
        static int nextVal = Rnd.Next(1, 300);
        string pre = "Initializing";
        string suf = ".";

        public LaunchScreen()
        {
            InitializeComponent();
        }

        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Pink;

                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroProgressBar1.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pre == "Done Loading Modules")
            {
                label1.Text = pre;
            }
            else
            {
                label1.Text = pre + suf;
            }

            if (label1.Text == "Initializing........." || label1.Text == "Loading Modules........." || label1.Text == "Creating Connection.........")
            {
                if (label1.Text == "Initializing.........")
                {
                    pre = "Initializing";
                    suf = ".";
                }
                else
                {
                    if (label1.Text == "Creating Connection.........")
                    {
                        pre = "Creating Connection";
                        suf = ".";
                    }
                    else
                    {
                        pre = "Loading Modules";
                        suf = ".";
                    }

                }
            }
            else
            {
                suf = suf + ".";
                //pre = "Initializing";
            }



            {

                if (progressBar1.Value < 300)
                {

                    //MessageBox.Show("timer");
                    if (progressBar1.Value == 80)
                    {
                        pre = "Creating Connection";
                    }
                    if (progressBar1.Value == 150)
                    {
                        pre = "Loading Modules";
                    }
                    if (progressBar1.Value == 280)
                    {
                        pre = "Done Loading Modules";
                    }
                    progressBar1.Value = progressBar1.Value + 1;
                }
                else
                {
                    timer1.Enabled = false;
                    this.Hide();
                    Loginfrm md = new Loginfrm();
                    md.Show();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LaunchScreen_Load(object sender, EventArgs e)
        {
            readingSettings();
        }
    }
}
