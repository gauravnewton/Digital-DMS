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
    public partial class StartUp : MetroForm
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                if (progressBar1.Value < 200)
                {
                    //MessageBox.Show("timer");
                    progressBar1.Value = progressBar1.Value + 1;
                }
                else
                {
                    timer1.Enabled = false;
                    this.Hide();
                    Admin_Registration ad = new Admin_Registration();
                    ad.Show();
                }
              
        }
    }
}
