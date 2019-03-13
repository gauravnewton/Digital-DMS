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
    public partial class ForcedActivation : MetroForm
    {
        public ForcedActivation()
        {
            InitializeComponent();
        }
        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;


                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;

                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Activation actv = new Activation();
            this.Hide();
            actv.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            LaunchScreen md = new LaunchScreen();
            this.Hide();
            md.Show();
        }

        private void ForcedActivation_Load(object sender, EventArgs e)
        {
            readingSettings();
        }
    }
}
