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
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;
using MetroFramework;

namespace DMS
{
    public partial class AddCategory : MetroForm
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(metroTextBox1.Text != "")
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd2;
                    string CmdString = "insert into file_categories(categoryname) values(@categoryname);";
                    cmd2 = new MySqlCommand(CmdString, con);
                    cmd2.Parameters.Add("@categoryname", MySqlDbType.VarChar, 100);

                    cmd2.Parameters["@categoryname"].Value = metroTextBox1.Text;

                    con.Open();
                    int RowAffected = cmd2.ExecuteNonQuery();
                    if(RowAffected > 0 )
                    {
                        con.Close();
                        MetroMessageBox.Show(this.MdiParent, "\nCateggory Added Successfully !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Dispose();
                    }
                    else
                    {
                        // not registered successfully
                        MetroMessageBox.Show(this, "\nSomething going to be wrong contact application vendor !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                catch(Exception oh)
                {
                    MetroMessageBox.Show(this, "\nSomething going to be wrong contact application vendor !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nEnter Category First !";
                popup.Popup();
            }
        }
        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }
        private void AddCategory_Load(object sender, EventArgs e)
        {
            readingSettings();
        }
    }
}
